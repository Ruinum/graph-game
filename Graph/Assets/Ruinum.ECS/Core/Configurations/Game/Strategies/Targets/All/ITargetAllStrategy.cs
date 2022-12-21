using System.Collections.Generic;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public interface ITargetAllStrategy
    {
        bool TryGet(GameEntity entity, List<GameEntity> targets);
    }
}