using Entitas;
using Entitas.CodeGeneration.Attributes;

using Ruinum.ECS.Services.Interfaces;


[Game][Unique]
public sealed class ServicesComponent : IComponent
{
    public IGameServices Instance;
}