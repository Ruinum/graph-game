using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies.ITargetStrategies
{
    public class EntityTypeTargetStrategy : ContextInitializable, ITargetStrategy
    {
        public ITargetStrategy Target;
        public EntityTypeConfig Config;

        public bool TryGet(GameEntity entity, out GameEntity result)
        {
            result = default;
            
            if (!Target.TryGet(entity, out var targetEntity))
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                    return false;
                }
            }

            if (!targetEntity.hasEntityType)
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(EntityTypeConfig), (nameof(targetEntity), targetEntity));
                    return false;
                }
            }

            if (targetEntity.entityType.Value.name != Config.name)
            {
                return false;
            }

            result = targetEntity;
            return true;
        }
    }
}