using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Services.Interfaces;

using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

using Object = UnityEngine.Object;

namespace Ruinum.ECS.Services
{
    public class AssetService : IAssetService
    {
        private readonly Dictionary<string, CachedAssetResource> _assetReferences = new Dictionary<string, CachedAssetResource>();

        public AsyncOperationHandle<IList<Object>> LoadAsync(IEnumerable keys, Addressables.MergeMode mode = Addressables.MergeMode.UseFirst)
        {
            return Addressables.ResourceManager.CreateChainOperation(Addressables.DownloadDependenciesAsync(keys, mode),
                m => LoadAssets(m, keys, mode));
        }

        public AsyncOperationHandle<IList<IResourceLocation>> UnloadAsync(IEnumerable keys, Addressables.MergeMode mode = Addressables.MergeMode.UseFirst)
        {
            var operation = Addressables.LoadResourceLocationsAsync(keys, mode);
            operation.Completed += LoadResourcesForUnloadCompleted;
            return operation;
        }

        private void LoadResourcesForUnloadCompleted(AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle)
        {
            var keysLocations = GetAssetKeysByLocations(asyncOperationHandle.Result);
            int counter = 0;
            for (int i = 0; i < keysLocations.Count; i++)
            {
                var cachedAssetResource = keysLocations[i];
                if (_assetReferences.Remove(cachedAssetResource.RunTimeKeyString))
                {
                    counter++;
                }
            }
            LogExtention.Log($"Unload completed: TotalAssets={counter}");
        }

        public bool TryGetAsset<T>(AssetReference assetReference, out T result) where T : Object
        {
            return TryGetAsset(assetReference.RuntimeKey, out result);
        }
        
        private AsyncOperationHandle<IList<Object>> Loaded(AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle)
        {
            var toLoad = new List<IResourceLocation>();
            var keysByIndex = new Dictionary<int, string>();
            var keysLocations = GetAssetKeysByLocations(asyncOperationHandle.Result);
            for (int i = 0; i < keysLocations.Count; i++)
            {
                var keyLocation = keysLocations[i];
                toLoad.Add(keyLocation.ResourceLocation);
                _assetReferences[keyLocation.RunTimeKeyString] = keyLocation;
                keysByIndex[i] = keyLocation.RunTimeKeyString;
            }
            var chain = Addressables.LoadAssetsAsync<Object>(toLoad, null);
            chain.Completed += m => LoadChainCompleted(m, keysByIndex);
            return chain;
        }

        private List<CachedAssetResource> GetAssetKeysByLocations(IList<IResourceLocation> locations)
        {
            var result = new List<CachedAssetResource>();
            var locationsId = new HashSet<string>(locations.Select(m => m.InternalId));
            foreach (var loc in Addressables.ResourceLocators)
            {
                foreach (var objKey in loc.Keys)
                {
                    if (!(objKey is string key))
                    {
                        continue;
                    }

                    if (!Guid.TryParse(key, out _))
                    {
                        continue;
                    }

                    if (!TryGetKeyInternalLocation(loc, key, out var location) || !locationsId.Contains(location.InternalId))
                    {
                        continue;
                    }

                    var entry = new CachedAssetResource
                    {
                        RunTimeKeyString = key,
                        ResourceLocation = location
                    };
                    result.Add(entry);
                }
            }
            return result;
        }

        private AsyncOperationHandle<IList<Object>> LoadAssets(AsyncOperationHandle arg, IEnumerable keys, Addressables.MergeMode mode)
        {
            return Addressables.ResourceManager.CreateChainOperation(Addressables.LoadResourceLocationsAsync(keys, mode), Loaded);
        }
        
        private void LoadChainCompleted(AsyncOperationHandle<IList<Object>> obj, Dictionary<int, string> keysByIndex)
        {
            for (int i = 0; i < obj.Result.Count; i++)
            {
                _assetReferences[keysByIndex[i]].Asset = obj.Result[i];
            }
            Addressables.Release(obj);
            LogExtention.Log($"LoadChain_Completed: TotalAssets={obj.Result.Count}");
        }

        private bool TryGetAsset<T>(object runtimeKey, out T result) where T : Object
        {
            if (_assetReferences.TryGetValue(EvaluateKey(runtimeKey), out var assetResource) && assetResource.Asset != null)
            {
                result = UnsafeUtility.As<Object, T>(ref assetResource.Asset);
                return true;
            }
            result = default;
            return false;
        }

        private static bool TryGetKeyInternalLocation(IResourceLocator locator, object key, out IResourceLocation internalLocation)
        {
            internalLocation = default;
            var hasLocation = locator.Locate(key, typeof(Object), out var keyLocations);
            if (!hasLocation)
                return false;
            if (keyLocations.Count == 0)
                return false;
            if (keyLocations.Count > 1)
                return false;

            internalLocation = keyLocations[0];
            return true;
        }

        private static string EvaluateKey(object obj)
        {
            return (string) (obj is IKeyEvaluator evaluator ? evaluator.RuntimeKey : obj);
        }

        private class CachedAssetResource
        {
            public IResourceLocation ResourceLocation;
            public Object Asset;
            public string RunTimeKeyString;
        }
    }
}
    
    