using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Ruinum.ECS.Services.Interfaces
{
    public interface IAssetService
    {
        AsyncOperationHandle<IList<Object>> LoadAsync(IEnumerable keys, Addressables.MergeMode mode = Addressables.MergeMode.UseFirst);

        AsyncOperationHandle<IList<IResourceLocation>> UnloadAsync(IEnumerable keys, Addressables.MergeMode mode = Addressables.MergeMode.UseFirst);
        
        bool TryGetAsset<T>(AssetReference assetReference, out T result) where T : Object;
    }
}