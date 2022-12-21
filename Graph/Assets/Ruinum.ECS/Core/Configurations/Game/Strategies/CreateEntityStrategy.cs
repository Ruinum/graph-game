using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Services.Interfaces;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class CreateEntityStrategy : ContextInitializable, IEntityStrategy
    {
        public IEntityConfigStrategy ConfigStrategy;
        
        public bool Process(GameEntity entity)
        {
            if (!ConfigStrategy.TryGet(entity, out var result))
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(result), (nameof(entity), entity));
                }
                return false;
            }
            
            result.Create();
            return true;
        }
    }
}