using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][Event(EventTarget.Self)]
public sealed class EntityListComponent : IComponent
{
    public List<GameEntity> Value = new List<GameEntity>();
}