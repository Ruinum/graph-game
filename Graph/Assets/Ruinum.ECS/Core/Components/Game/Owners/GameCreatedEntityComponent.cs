using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class GameCreatedEntityComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}