using Entitas;
using UnityEngine.ResourceManagement.AsyncOperations;

[Game]
public sealed class SceneLoadProgressComponent : IComponent
{
    public AsyncOperationHandle Value;
}