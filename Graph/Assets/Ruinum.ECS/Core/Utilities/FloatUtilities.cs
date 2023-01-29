using System;
using Ruinum.ECS.Configurations;

namespace Ruinum.ECS.Utilities
{
    public static class FloatUtilities
    {
        public static float GetModifiedValue(ModifierType modifier, float value, float modifierValue)
        {
            switch (modifier)
            {
                case ModifierType.Plus: value += modifierValue; break;
                case ModifierType.Minus: value -= modifierValue; break;
                case ModifierType.Multiply: value *= modifierValue; break;
                case ModifierType.Divide: value /= modifierValue; break;
                default: throw new ArgumentOutOfRangeException(nameof(value), $"Modifier of type {modifier} not found");
            }
            return value;
        }
    }
}