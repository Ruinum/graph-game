using Ruinum.ECS.Configurations.Input;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
[Input]
public sealed class InputDomainComponent : IComponent
{
    public InputDomainConfig Config;
}