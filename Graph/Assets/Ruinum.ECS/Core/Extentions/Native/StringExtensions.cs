using System;
using System.Globalization;
using System.Text;

namespace Ruinum.ECS.Core.Extensions.Native
{
    public static class StringExtensions
    {
        public static string FirstCharacterToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s) || char.IsUpper(s, 0))
            {
                return s;
            }

            return char.ToUpperInvariant(s[0]) + s.Substring(1);
        }
        
        public static bool IsDigit(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string PascalCaseToCamelCase(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return value;
            }
            var first = value[0].ToString().ToLower();
            return first + value.Substring(1, value.Length - 1);
        }

        public static T ParseEnum<T>(this string enumValueString, T defaultValue)
        {
            T result;
            try
            {
                result = (T)Enum.Parse(typeof(T), enumValueString, true);
            }
            catch (Exception)
            {
                result = defaultValue;
            }
            return result;
        }

        public static bool TryParseDouble(this string text, out double number)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out number);
        }

        public static double ParseDouble(this string text)
        {
            return double.Parse(text, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public static bool TryParseFloat(this string text, out float number)
        {
            return float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out number);
        }

        public static float ParseFloat(this string text)
        {
            return float.Parse(text, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public static bool ParseBool(this string text)
        {
            return bool.Parse(text);
        }

        public static string RemoveAll(this string source, params string[] oldValues)
        {
            return source.ReplaceAll(string.Empty, oldValues);
        }

        public static string ReplaceAll(this string source, string newValue, params string[] oldValues)
        {
            var builder = new StringBuilder(source);
            for (int i = 0, max = oldValues.Length; i < max; i++)
            {
                builder.Replace(oldValues[i], newValue);
            }
            return builder.ToString();
        }

        public static string ToStringRow(this object[] data)
        {
            if (data == null)
            {
                return "null";
            }
            var sb = new string[data.Length];
            for (int i = 0, max = data.Length; i < max; i++)
            {
                var o = data[i];
                sb[i] = o != null ? o.ToString() : "null";
            }
            return string.Join(", ", sb);
        }
    }
}