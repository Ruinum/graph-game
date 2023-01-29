using Ruinum.ECS.Core;
using System;

namespace Ruinum.ECS.Utilities
{
    public class ConditionUtilities
    {
        public static bool IsConditionTrue(EqualityType type, float a, float b)
        {
            return type switch
            {
                EqualityType.Equal => Math.Abs(a - b) < 0.0001f,
                EqualityType.Greater => a > b,
                EqualityType.Less => a < b,
                EqualityType.NotEqual => Math.Abs(a - b) > 0.0001f,
                EqualityType.GreaterOrEqual => a >= b,
                EqualityType.LessOrEqual => a <= b,
                _ => false
            };
        }
    }
}