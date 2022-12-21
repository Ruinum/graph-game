using System.Collections.Generic;
using Entitas;

public abstract class EntityPublisherComponent : IComponent
{
    public List<GameEntity> Subscribers;
}