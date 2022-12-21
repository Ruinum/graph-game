using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Strategies;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class EntityConfigFromComponentStrategy : ContextInitializable, IEntityConfigStrategy
    {

        public bool TryGet(GameEntity entity, out GameEntityConfig result)
        {
            result = default;

            if (!entity.hasTargetEntityConfig)
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(TargetEntityConfigComponent), (nameof(entity), entity));
                }
                return false;
            }

            return entity.targetEntityConfig.Value;
        }
    }
}