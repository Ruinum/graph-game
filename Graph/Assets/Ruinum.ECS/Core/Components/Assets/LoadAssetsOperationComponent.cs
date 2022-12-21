using Entitas;
using UnityEngine.ResourceManagement.AsyncOperations;

[Game]
public sealed class LoadAssetsOperationComponent : IComponent
{
    public AsyncOperationHandle Operation;
}