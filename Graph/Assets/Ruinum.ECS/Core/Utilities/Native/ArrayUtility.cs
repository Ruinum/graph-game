using System;

namespace Ruinum.ECS.Core.Utility.Native
{
    public static class ArrayUtility
    {
        public static void Add<T>(ref T[] array, T element)
        {
            Expand(ref array);
            array[array.Length - 1] = element;
        }

        public static void Insert<T>(ref T[] array, T element, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                Expand(ref array);
                for (var i = array.Length - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = element;
            }
            else
            {
                throw new IndexOutOfRangeException("index");
            }
        }

        public static void RemoveAt<T>(ref T[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                for (var i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Shrink(ref array);
            }
            else
            {
                throw new IndexOutOfRangeException("index");
            }
        }

        public static void Remove<T>(ref T[] array, T element)
        {
            RemoveAt(ref array, FindIndex(ref array, element));
        }

        public static void Expand<T>(ref T[] array)
        {
            Array.Resize(ref array, array.Length + 1);
        }

        public static void Shrink<T>(ref T[] array)
        {
            if (array.Length > 0) Array.Resize(ref array, array.Length - 1);
        }

        public static void Resize<T>(ref T[] array, int size)
        {
            Array.Resize(ref array, size);
        }

        public static void Clear<T>(ref T[] array)
        {
            Array.Resize(ref array, 0);
        }

        public static int FindIndex<T>(ref T[] array, T element)
        {
            return Array.FindIndex(array, x => x.Equals(element));
        }

        public static T Find<T>(ref T[] array, T element)
        {
            return Array.Find(array, x => x.Equals(element));
        }

        public static bool Contains<T>(ref T[] array, T element)
        {
            return FindIndex(ref array, element) >= 0;
        }

        public static T[] Concat<T>(T[] lhs, T[] rhs)
        {
            var result = new T[lhs.Length + rhs.Length];
            lhs.CopyTo(result, 0);
            rhs.CopyTo(result, lhs.Length);
            return result;
        }

        public static T[] Concat<T>(T lhs, T[] rhs)
        {
            var clone = (T[]) rhs.Clone();
            Insert(ref clone, lhs, 0);
            return clone;
        }

        public static T[] Concat<T>(T[] lhs, T rhs)
        {
            var clone = (T[])lhs.Clone();
            Add(ref clone, rhs);
            return clone;
        }

        public static float[] Add(float[] lhs, float[] rhs)
        {
            if (lhs.Length != rhs.Length)
            {
                return null;
            }
            var result = new float[lhs.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
            return result;
        }

        public static float[] Add(float[] lhs, float value)
        {
            var result = new float[lhs.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = lhs[i] + value;
            }
            return result;
        }

        public static float[] Sub(float[] lhs, float[] rhs)
        {
            if (lhs.Length != rhs.Length) return null;
            var result = new float[lhs.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = lhs[i] - rhs[i];
            }
            return result;
        }

        public static float[] Sub(float[] lhs, float value)
        {
            var result = new float[lhs.Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = lhs[i] - value;
            }
            return result;
        }
    }
}