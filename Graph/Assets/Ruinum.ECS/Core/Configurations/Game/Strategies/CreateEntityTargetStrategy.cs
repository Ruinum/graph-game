using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class CreateEntityTargetStrategy : ContextInitializable, IEntityStrategy
    {
        public IEntityConfigStrategy EntityConfig;
        public ITargetStrategy Target;
        
        public bool Process(GameEntity entity)
        {
            if (!EntityConfig.TryGet(entity, out var config))
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(config), (nameof(entity), entity));
                }
                return false;
            }
            
            if (!Target.TryGet(entity, out var targetEntity))
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                }
                return false;
            }
            
            config.Create(targetEntity);
            return true;
        }
    }
}