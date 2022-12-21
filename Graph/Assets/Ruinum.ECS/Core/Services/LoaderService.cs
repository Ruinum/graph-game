using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Ruinum.ECS.Constants;
using Ruinum.ECS.Scripts.UI.Windows.Loader;

using System.Threading.Tasks;

namespace Ruinum.ECS.Services.Interfaces
{
    public sealed class LoaderService : ILoaderService
    {
        public bool IsActive
        {
            get => _loader.gameObject.activeSelf;
            set => _loader.gameObject.SetActive(value);
        }

        private LoaderWindow _loader;

        public async Task PostInitializeAsync() =>
            await Task.CompletedTask;

        public async Task PreInitializeAsync()
        {
            Debug.Log("Loading assets");

            var operation = Addressables.InstantiateAsync(UiConstants.LoaderAssetName,
                GameObject.FindGameObjectWithTag(UiConstants.RootCanvasTag).transform);
            await operation.Task;
            Debug.Log("Wait task");
            if (operation.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Task Succeeded");
                _loader = operation.Result.GetComponent<LoaderWindow>();
                IsActive = false;
            }
        }

        public void UpdateProgress(float progress)
        {
            _loader.UpdateProgress(progress);
        }
    }
}