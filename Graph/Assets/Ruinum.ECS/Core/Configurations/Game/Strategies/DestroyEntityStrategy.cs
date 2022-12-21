using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class DestroyEntityStrategy: EntityStrategy
    {
        public ITargetStrategy Target;

        public override bool Process(GameEntity entity)
        {
            if(!Target.TryGet(entity, out var target)) { return false; };
            target.isDestroyed = true;
            return true;
        }
    }
}