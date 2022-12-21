using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][System.Serializable]
public sealed class GameTargetComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}
