using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Core.Extensions.Native;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class MinMaxClampFloatValueStrategy : ModifierStrategy
    {
        public TargetStrategy MinMaxTargetStrategy;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            result = currentValue;
            if (!MinMaxTargetStrategy.TryGet(entity, out var target))
            {
                return false;
            }
            if (target.hasMaxFloatValue)
            {
                result = result.ClampMax(target.maxFloatValue.Value);
            }
            if (target.hasMinFloatValue)
            {
                result = result.ClampMin(target.minFloatValue.Value);
            }
            return true;
        }
    }
}