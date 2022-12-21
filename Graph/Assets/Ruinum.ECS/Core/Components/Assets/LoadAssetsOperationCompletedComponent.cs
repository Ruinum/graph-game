using Entitas;
using UnityEngine.ResourceManagement.AsyncOperations;

[Game]
public sealed class LoadAssetsOperationCompletedComponent : IComponent
{
    public AsyncOperationStatus Status;
}