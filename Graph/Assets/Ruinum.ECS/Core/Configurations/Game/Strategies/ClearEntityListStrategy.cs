using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public sealed class ClearEntityListStrategy : EntityStrategy
    {
        public ITargetStrategy Target;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                LogErrorNotFound("", ("Strategy", Target), ("Entity", entity));
                return false;
            }

            if (!target.hasEntityList)
            {
                LogErrorNotFound($"Didn't have {nameof(EntityListComponent)}", ("Target", target), ("Entity", entity));
                return false;
            }

            target.entityList.Value.Clear();
            return true;
        }
    }
}