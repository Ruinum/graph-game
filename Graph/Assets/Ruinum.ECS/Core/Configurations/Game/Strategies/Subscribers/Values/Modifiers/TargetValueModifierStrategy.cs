using Ruinum.ECS.Utilities;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class TargetValueModifierStrategy : ModifierStrategy
    {
        public IFloatValueStrategy Value;
        public ModifierType Modifier;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            if (Value.TryGet(entity, out var value))
            {
                result = FloatUtilities.GetModifiedValue(Modifier, value, currentValue);
                return true;
            }
            result = default;
            return false;
        }
    }
}