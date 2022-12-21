using Ruinum.ECS.Configurations.Game.Strategies;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public abstract class EntityStrategy : ContextInitializable, IEntityStrategy
    {
        public abstract bool Process(GameEntity entity);
    }
}