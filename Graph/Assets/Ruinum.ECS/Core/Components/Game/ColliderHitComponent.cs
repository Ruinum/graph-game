using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][System.Serializable]
public sealed class ColliderHitComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}
