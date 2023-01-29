using System;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class RoundToWholeNumberModifierStrategy : ModifierStrategy
    {
        public FloatRoundType RoundType;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            switch (RoundType)
            {
                case FloatRoundType.Floor: result = Mathf.Floor(currentValue); return true;
                case FloatRoundType.Ceil: result = Mathf.Ceil(currentValue); return true;
                case FloatRoundType.Nearest: result = Mathf.Round(currentValue); return true;
                default: throw new ArgumentOutOfRangeException(nameof(RoundType), "Unknown round type in " + nameof(RoundToWholeNumberModifierStrategy));
            }
        }
    }
}