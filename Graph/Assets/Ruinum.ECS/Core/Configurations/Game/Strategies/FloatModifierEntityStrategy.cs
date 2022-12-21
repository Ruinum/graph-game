using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class FloatModifierEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public IFloatValueStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target)) { return false; };
            if (!Strategy.TryGet(entity, out var value)) { return false; }
            if (!target.hasFloatModifier) { return false; }

            target.ReplaceFloatModifier(value);

            return true;
        }
    }
}