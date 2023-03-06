using System.Collections.Generic;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public abstract class FilterTargetAllStrategy : ContextInitializable, IFilterTargetAllStrategy
    {
        public abstract bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer);
    }
}