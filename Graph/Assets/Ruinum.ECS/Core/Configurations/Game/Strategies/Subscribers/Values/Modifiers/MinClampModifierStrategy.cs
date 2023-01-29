using Ruinum.ECS.Core.Utility.Native;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class MinClampModifierStrategy : ModifierStrategy
    {
        public IFloatValueStrategy MinValue;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            if (MinValue.TryGet(entity, out var min))
            {
                result = MathUtility.ClampMin(currentValue, min);
                return true;
            }
            result = default;
            return false;
        }
    }
}