using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Ruinum.ECS.Services.Interfaces
{
    public interface ISceneService
    {
        bool TryLoadScene(AssetReference sceneReference, LoadSceneMode loadMode, out AsyncOperationHandle result);
    }
}