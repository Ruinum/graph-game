using System;
using System.Collections.Generic;

using UnityEngine;

namespace Ruinum.ECS.Core.Utility.Native
{
    public static class MathUtility
    {
        public const float FloatEpsilon = 1.175494E-38f;
        public static readonly float FloatComparisonTolerance = Mathf.Epsilon;

        public static T Max<T>(T first, T second)
        {
            return Compare(first, second) > 0 ? first : second;
        }

        public static T Min<T>(T first, T second)
        {
            return Compare(first, second) < 0 ? first : second;
        }

        public static TSource Min<TSource, TComparer>(TSource first, TSource second, Converter<TSource, TComparer> selector)
        {
            return Compare(selector.Invoke(first), selector.Invoke(second)) < 0 ? first : second;
        }

        public static TSource Max<TSource, TComparer>(TSource first, TSource second, Converter<TSource, TComparer> selector)
        {
            return Compare(selector.Invoke(first), selector.Invoke(second)) > 0 ? first : second;
        }

        private static int Compare<T>(T first, T second)
        {
            return Comparer<T>.Default.Compare(first, second);
        }

        public static float ClampZero(float value)
        {
            return IsEqual(value, 0.0f) ? FloatComparisonTolerance : value;
        }

        public static int Clamp(int value, int from, int to)
        {
            return from < to
                ? value < from ? from : value > to ? to : value
                : value < to ? to : value > from ? from : value;
        }

        public static float Clamp(float value, float from, float to)
        {
            return from < to
                   ? value < from ? from : value > to ? to : value
                   : value < to ? to : value > from ? from : value;
        }

        public static float ClampMax(float value, float maxValue)
        {
            return value > maxValue ? maxValue : value;
        }

        public static float ClampMin(float value, float minValue)
        {
            return value < minValue ? minValue : value;
        }

        public static bool IsEqualByEpsilon(float compared, float compareTo)
        {
            return IsEqual(compared, compareTo, FloatEpsilon);
        }

        public static bool IsEqual(float compared, float compareTo)
        {
            return IsEqual(compared, compareTo, FloatComparisonTolerance);
        }

        public static bool IsEqual(float compared, float compareTo, float tolerance)
        {
            return IsEqual((double)compared, (double)compareTo, tolerance);
        }

        public static bool IsEqual(double compared, double compareTo, float tolerance)
        {
            return Math.Abs(compared - compareTo) <= tolerance;
        }

        public static float ConvertLinearRange(float currentRangeValue, float currentRangeMin, float currentRangeMax, float newRangeMin, float newRangeMax)
        {
            return (currentRangeValue - currentRangeMin) / (currentRangeMax - currentRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
        }

        public static float ConvertLogToLinearRange(float convertValue, float logRangeMin, float logRangeMax, float power, float linearRangeMin, float linearRangeMax)
        {
            return (float)ConvertLogToLinearRange((double)convertValue, (double)logRangeMin, (double)logRangeMax, (double)power, (double)linearRangeMin, (double)linearRangeMax);
        }

        public static double ConvertLogToLinearRange(double convertValue, double logRangeMin, double logRangeMax, double power, double linearRangeMin, double linearRangeMax)
        {
            return linearRangeMin +
                   (Math.Pow(power, convertValue) - Math.Pow(power, logRangeMin)) /
                   (Math.Pow(power, logRangeMax) - Math.Pow(power, logRangeMin)) *
                   (linearRangeMax - linearRangeMin);
        }

        public static float ConvertLinearToLogRange(float convertValue, float linearRangeMin, float linearRangeMax, float logRangeMin, float logRangeMax, float power)
        {
            return (float)ConvertLinearToLogRange((double)convertValue, (double)linearRangeMin, (double)linearRangeMax, (double)logRangeMin, (double)logRangeMax, (double)power);
        }

        public static double ConvertLinearToLogRange(double convertValue, double linearRangeMin, double linearRangeMax, double logRangeMin, double logRangeMax, double power)
        {
            return Math.Log((convertValue - linearRangeMin) / (linearRangeMax - linearRangeMin) * (Math.Pow(power, logRangeMax) -
                              Math.Pow(power, logRangeMin)) + Math.Pow(power, logRangeMin), power);
        }
    }
}