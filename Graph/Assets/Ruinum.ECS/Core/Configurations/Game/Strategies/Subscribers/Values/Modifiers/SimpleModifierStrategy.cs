using Ruinum.ECS.Utilities;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public class SimpleModifierStrategy : ModifierStrategy
    {
        public ModifierType Modifier;
        public IFloatValueStrategy ModifierValueStrategy;
        
        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            if (ModifierValueStrategy.TryGet(entity, out var modifierValue))
            {
                result = FloatUtilities.GetModifiedValue(Modifier, currentValue, modifierValue);
                return true;
            }
            result = currentValue;
            return false;
        }
    }
}