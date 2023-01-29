using Ruinum.ECS.Utilities;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class DeltaTimeModifierStrategy : ModifierStrategy
    {
        public ModifierType Modifier;
        public IFloatValueStrategy ModifierValueStrategy;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            if (ModifierValueStrategy.TryGet(entity, out var modifierValue))
            {
                result = FloatUtilities.GetModifiedValue(Modifier, currentValue, Time.deltaTime * modifierValue);
                return true;
            }
            result = default;
            return false;
        }
    }
}