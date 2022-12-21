using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Ruinum.ECS.Core.Extensions.Native
{
    public static class ArrayExtensions
    {
        public static bool IsIndex<T>(this T[] array, int index)
        {
            return index < array.Length && index >= 0;
        }
        
        public static T[] Copy<T>(this T[] source)
        {
            var length = source.Length;
            var destination = new T[length];
            Array.Copy(source, destination, length);
            return destination;
        }

        public static T Find<T>(this T[] array, Predicate<T> match) 
        {
            for (int i = 0, max = array.Length; i < max; i++)
            {
                if (match.Invoke(array[i]))
                {
                    return array[i];
                }
            }
            return default;
        }

        public static T[] Concat<T>(this T[] array, T item)
        {
            return array == null ? new[] { item } : array.Concat(new[] { item }).ToArray();
        }

        public static bool Contains<T>(this T[] array, T item)
        {
            for (int i = 0, max = array.Length; i < max; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            var list = new List<T>();
            for (int i = 0, max = array.Length; i < max; i++)
            {
                if (!match.Invoke(array[i]))
                {
                    continue;
                }
                list.Add(array[i]);

            }
            return list.ToArray();
        }

        public static int IndexOf<T>(this T[] array, Predicate<T> match)
        {
            for (int i = 0, max = array.Length; i < max; i++)
            {
                if (match.Invoke(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int IndexOf<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }

        public static int IndexOf<T>(this Type[] array)
        {
            return Array.IndexOf(array, typeof(T));
        }

        public static int Sum(this int[] values)
        {
            var sum = 0;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += values[i];
            }
            return sum;
        }

        public static float Sum(this float[] values)
        {
            var sum = 0f;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += values[i];
            }
            return sum;
        }

        public static double Sum(this double[] values)
        {
            var sum = 0.0;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += values[i];
            }
            return sum;
        }

        public static int AbsSum(this int[] values)
        {
            var sum = 0;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += Math.Abs(values[i]);
            }
            return sum;
        }

        public static float AbsSum(this float[] values)
        {
            var sum = 0f;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += Math.Abs(values[i]);
            }
            return sum;
        }

        public static double AbsSum(this double[] values)
        {
            var sum = 0.0;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += Math.Abs(values[i]);
            }
            return sum;
        }

        public static int Min(this int[] values)
        {
            if (values.Length == 0)
            {
                return int.MinValue;
            }
            var min = int.MaxValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                min = Math.Min(min, values[i]);
            }
            return min;
        }

        public static float Min(this float[] values)
        {
            if (values.Length == 0)
            {
                return float.MinValue;
            }
            var min = float.MaxValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                min = Math.Min(min, values[i]);
            }
            return min;
        }

        public static double Min(this double[] values)
        {
            if (values.Length == 0)
            {
                return double.MinValue;
            }
            var min = double.MaxValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                min = Math.Min(min, values[i]);
            }
            return min;
        }

        public static int Max(this int[] values)
        {
            if (values.Length == 0)
            {
                return int.MaxValue;
            }
            var max = int.MinValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }

        public static float Max(this float[] values)
        {
            if (values.Length == 0)
            {
                return float.MaxValue;
            }
            var max = float.MinValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }

        public static double Max(this double[] values)
        {
            if (values.Length == 0)
            {
                return double.MaxValue;
            }
            var max = double.MinValue;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, values[i]);
            }
            return max;
        }

        public static float Mean(this int[] values)
        {
            if (values.Length == 0)
            {
                return 0;
            }
            var mean = 0f;
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                mean += values[i];
            }
            return mean / count;
        }

        public static float Mean(this float[] values)
        {
            if (values.Length == 0)
            {
                return 0f;
            }
            var mean = 0f;
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                mean += values[i];
            }
            return mean / count;
        }

        public static double Mean(this double[] values)
        {
            if (values.Length == 0)
            {
                return 0.0;
            }
            var mean = 0.0;
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                mean += values[i];
            }
            return mean / count;
        }

        public static float Sigma(this int[] values)
        {
            if (values.Length == 0)
            {
                return 0f;
            }
            var variance = 0f;
            var mean = values.Mean();
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                variance += Mathf.Pow(values[i] - mean, 2f);
            }
            return Mathf.Sqrt(variance / count);
        }

        public static float Sigma(this float[] values)
        {
            if (values.Length == 0)
            {
                return 0f;
            }
            var variance = 0f;
            var mean = values.Mean();
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                variance += Mathf.Pow(values[i] - mean, 2f);
            }
            return Mathf.Sqrt(variance / count);
        }

        public static double Sigma(this double[] values)
        {
            if (values.Length == 0)
            {
                return 0.0;
            }
            var variance = 0.0;
            var mean = values.Mean();
            var count = values.Length;
            for (int i = 0; i < count; i++)
            {
                variance += Math.Pow(values[i] - mean, 2f);
            }
            return Math.Sqrt(variance / count);
        }

        public static void Zero(this float[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
            {
                values[i] = 0f;
            }
        }
    }
}