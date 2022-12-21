using Ruinum.ECS.Core.Utility.Native;
using System;

namespace Ruinum.ECS.Core.Extensions.Native
{
    public static class NativeExtensions
    {
        private const int MillisecondsInSecond = 1000;
        private const string Null = "Null";

        public static float ToSeconds(this int milliseconds)
        {
            return (float) milliseconds / MillisecondsInSecond;
        }

        public static float ToMilliseconds(this float seconds)
        {
            return seconds * MillisecondsInSecond;
        }

        public static bool IsEqual(this int number, Enum value)
        {
            try
            {
                return number == Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsEqual(this float number, float value)
        {
            return MathUtility.IsEqual(number, value);
        }


        public static bool IsAliveTarget(this WeakReference reference)
        {
            return reference.Target != null && !reference.Target.Equals(null) && reference.IsAlive;  
        }

        public static int Clamp(this int value, int minValue, int maxValue)
        {
            return MathUtility.Clamp(value, minValue, maxValue);
        }

        public static float Clamp(this float value, float minValue, float maxValue)
        {
            return MathUtility.Clamp(value, minValue, maxValue);
        }

        public static float ClampMin(this float value, float minValue)
        {
            return MathUtility.ClampMin(value, minValue);
        }

        public static float ClampMax(this float value, float maxValue)
        {
            return MathUtility.ClampMax(value, maxValue);
        }

        public static string GetTypeName(this object o)
        {
            return o == null ? Null : o.GetType().Name;
        }
    }
}