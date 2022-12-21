using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][System.Serializable]
public sealed class CreatedEntityComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}
