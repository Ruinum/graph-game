using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Services.Interfaces;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Ruinum.ECS.Services
{
    public sealed class SceneService : ISceneService
    {
        public bool TryLoadScene(AssetReference sceneReference, LoadSceneMode loadMode, out AsyncOperationHandle result)
        {
            result = Addressables.LoadSceneAsync(sceneReference, loadMode);
            if (result.Status == AsyncOperationStatus.Failed)
            {
                LogExtention.Error($"Failed to load scene [{sceneReference}] with mode [{loadMode.ToString()}]");
                return false;
            }
            return true;
        }
    }
}