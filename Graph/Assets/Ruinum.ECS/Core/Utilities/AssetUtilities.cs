using Ruinum.ECS.Core.Extensions.Unity;

using UnityEditor;
using UnityEngine;

using Object = UnityEngine.Object;

namespace Ruinum.ECS.Utilities
{
    public static class AssetUtilities
    {
#if UNITY_EDITOR        
        public static void CreateAsset(Object obj, string folderPath, string fileName)
        {
            AssetDatabase.CreateAsset(obj, $"{folderPath}/{fileName}.asset");
            AssetDatabase.SaveAssets();
        }

        public static void SetDirtyAll<T>() where T : ScriptableObject
        {
            foreach (var guid in AssetDatabase.FindAssets($"t:{typeof(T).Name}"))
            {
                var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
                if (!asset.IsNull())
                {
                    EditorUtility.SetDirty(asset);
                }
            }
        }
#endif
    }
}