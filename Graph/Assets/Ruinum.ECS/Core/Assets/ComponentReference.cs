using System;

using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Object = UnityEngine.Object;

namespace Ruinum.ECS.Assets
{
    [System.Serializable]
    public class ComponentReference<T> : AssetReference where T : Object
    {
        public ComponentReference(string guid) : base(guid) { }

        public new AsyncOperationHandle<T> InstantiateAsync(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return Addressables.ResourceManager.CreateChainOperation(base.InstantiateAsync(position, rotation, parent), GameObjectReady);
        }

        public new AsyncOperationHandle<T> InstantiateAsync(Transform parent = null, bool instantiateInWorldSpace = false)
        {
            return Addressables.ResourceManager.CreateChainOperation(base.InstantiateAsync(parent, instantiateInWorldSpace), GameObjectReady);
        }
        
        public T InstantiateSync(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var operation = Addressables.ResourceManager.CreateChainOperation(base.InstantiateAsync(position, rotation, parent), GameObjectReady);
            if (operation.IsDone)
            {
                return operation.Result;
            }
#if UNITY_EDITOR
            throw new NullReferenceException($"InstantiateSync operation has not completed yet. {editorAsset.name}");
#else       
            throw new NullReferenceException($"InstantiateSync operation has not completed yet. {typeof(T)}");
#endif
        }

        public T InstantiateSync(Transform parent = null, bool instantiateInWorldSpace = false)
        {
            var operation = Addressables.ResourceManager.CreateChainOperation(base.InstantiateAsync(parent, instantiateInWorldSpace), GameObjectReady);
            if (operation.IsDone)
            {
                return operation.Result;
            }
#if UNITY_EDITOR
            throw new NullReferenceException($"InstantiateSync operation has not completed yet. {editorAsset.name}");
#else
            throw new NullReferenceException($"InstantiateSync operation has not completed yet. {typeof(T)}");
#endif
        }

        public AsyncOperationHandle<T> LoadAssetAsync()
        {
            return Addressables.ResourceManager.CreateChainOperation(base.LoadAssetAsync<GameObject>(), GameObjectReady);
        }

        private AsyncOperationHandle<T> GameObjectReady(AsyncOperationHandle<GameObject> arg)
        {
            return Addressables.ResourceManager.CreateCompletedOperation(arg.Result.GetComponent<T>(), string.Empty);
        }

        public override bool ValidateAsset(Object obj)
        {
            var go = obj as GameObject;
            return go != null && go.GetComponent<T>() != null;
        }

        public override bool ValidateAsset(string path)
        {
#if UNITY_EDITOR
            var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            return go != null && go.GetComponent<T>() != null;
#else
            return false;
#endif
        }

        public void ReleaseInstance(AsyncOperationHandle<T> op)
        {
            var component = op.Result as Component;
            if (component != null)
            {
                Addressables.ReleaseInstance(component.gameObject);
            }
            Addressables.Release(op);
        }
    }
}