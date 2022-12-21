using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class ConfigIndexComponent : IComponent
{
    [EntityIndex]
    public uint Value;
    public int EntityIdentity;
}