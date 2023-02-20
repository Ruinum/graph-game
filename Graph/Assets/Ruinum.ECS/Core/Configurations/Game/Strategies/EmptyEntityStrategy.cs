using Ruinum.ECS.Configurations.Game.Strategies;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class EmptyEntityStrategy : EntityStrategy
    {
        public override bool Process(GameEntity entity)
        {
            return true;
        }
    }
}