using Entitas;
using Ruinum.ECS.Configurations.Game;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class ChildTransformByConfigComponent : IComponent
{
    public GameEntityConfig Config;
}