using System;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Ruinum.ECS.Core.Extensions.Unity.Editor
{
    public static class AssetDatabaseExtensions
    {
        private const string Empty = "";

        public static string AssetPath(this Object value)
        {
            return AssetDatabase.GetAssetPath(value);
        }

        public static string AssetPath(this Object value, string oldValue, string newValue = Empty)
        {
            return value.AssetPath().Replace(oldValue, newValue);
        }

        public static string AssetName(this Object value)
        {
            var path = value.AssetPath();
            var index = path.LastIndexOf("/", StringComparison.Ordinal);
            var length = path.Length - index - 1;
            return path.Substring(index, length);
        }

        public static string AssetName(this Object value, string oldValue, string newValue = Empty)
        {
            return value.AssetName().Replace(oldValue, newValue);
        }
    }
}