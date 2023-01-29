using Ruinum.ECS.Core.Utility.Native;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class MaxClampModifierStrategy : ModifierStrategy
    {
        public IFloatValueStrategy MaxValue;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            if (MaxValue.TryGet(entity, out var max))
            {
                result = MathUtility.ClampMax(currentValue, max);
                return true;
            }
            result = default;
            return false;
        }
    }
}