using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][System.Serializable]
public sealed class CreatorEntityComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}
