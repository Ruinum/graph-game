using System.Collections.Generic;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public abstract class TargetAllStrategy : ContextInitializable, ITargetAllStrategy
    {
        public abstract bool TryGet(GameEntity entity, List<GameEntity> targets);
    }
}