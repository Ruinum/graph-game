using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Core.Configurations.Game.Strategies;
namespace Ruinum.ECS.Configurations.Game.Indexes
{
    public class CreateEntityByCountStrategy : ContextInitializable, IEntityStrategy
    {
        public List<IEntityConfigStrategy> EntityConfigs;

        public bool Process(GameEntity entity)
        {
            foreach (var strategy in EntityConfigs)
            {
                if (!strategy.TryGet(entity, out var result))
                {
                    if (Logging)
                    {
                        LogErrorNotFound(nameof(result), (nameof(entity), entity));
                    }
                    return false;
                }
            
                result.Create();
            }
            
            return true;
        }
    }
}