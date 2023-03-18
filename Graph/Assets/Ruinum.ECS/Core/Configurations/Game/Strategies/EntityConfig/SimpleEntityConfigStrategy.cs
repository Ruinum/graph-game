using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Strategies;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SimpleEntityConfigStrategy : ContextInitializable, IEntityConfigStrategy
    {
        public GameEntityConfig EntityConfig;
        
        public bool TryGet(GameEntity entity, out GameEntityConfig result)
        {
            result = EntityConfig;
            
            return true;
        }
    }
}