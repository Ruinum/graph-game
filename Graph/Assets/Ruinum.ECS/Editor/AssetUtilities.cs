using System;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Ruinum.ECS.Editor
{
    public static class AssetUtilities 
    {
        public static List<T> GetAssetsInFolder<T>(string path) where T : Object
        {
            var result = new List<T>();
            foreach (var guid in AssetDatabase.FindAssets(string.Empty, new[] {path}))
            {
                result.Add(AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            return result;
        }
        
        public static List<T> GetAllAssets<T>() where T : Object
        {
            var result = new List<T>();
            foreach (var guid in AssetDatabase.FindAssets($"t:{typeof(T).Name}"))
            {
                result.Add(AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            return result;
        }
        
        public static List<Object> GetAllAssets(Type type)
        {
            var result = new List<Object>();
            foreach (var guid in AssetDatabase.FindAssets($"t:{type.Name}"))
            {
                result.Add(AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), type));
            }
            return result;
        }
    }
}