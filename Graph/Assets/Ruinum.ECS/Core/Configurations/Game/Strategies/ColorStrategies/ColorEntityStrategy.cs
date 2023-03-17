using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class ColorEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public IColorStrategy ColorStrategy;
        public override bool Process(GameEntity entity)
        {
            if(!Target.TryGet(entity, out var target))
            {
                return false;
            }
            if(!ColorStrategy.TryGet(entity, out var color))
            { 
                return false; 
            }
            target.ReplaceColor(color);
            return true;
        }
    }
}
