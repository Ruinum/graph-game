using Ruinum.ECS.Configurations;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Editor.Validation;
using Ruinum.ECS.Services;
using Ruinum.ECS.Utilities;

using UnityEditor;
using UnityEngine;


namespace Ruinum.Editor.Validation
{
    public static class ValidationEditor
    {
        [MenuItem(EditorConstants.RootMenuValidationPath + "Validate ALL ", false, EditorConstants.ValidationEditorValidateAllPriority)]
        public static void ValidateAll()
        {
            LogExtention.Log("Validation process...");
            ValidateConfigIndexes();
            ReferenceValidationEditor.ValidateLog();
            LogExtention.Log("Validation finished");
        }
        
        [MenuItem(EditorConstants.RootMenuValidationPath + "Set Dirty All ", false)]
        public static void SetDirtyAll()
        {
            ValidateConfigIndexes();
            var config = ConfigService.LoadConfigIndexEditor();
            config.GetConfigs().ForEach(EditorUtility.SetDirty);
            AssetUtilities.SetDirtyAll<InitializableConfig>();
            AssetUtilities.SetDirtyAll<InitializableSerializedConfig>();
        }

        [MenuItem(EditorConstants.RootMenuConfigPath + "Index configs", false, EditorConstants.ConfigsInitializeOnLoadPriority)]
        public static void ValidateConfigIndexes()
        {
            ValidateEditor(ConfigService.LoadConfigIndexEditor());
            ValidateEditor(ConfigService.LoadComponentDataContainerConfigIndexEditor());
        }

        private static void ValidateEditor<T>(IConfigIndex<T> index) where T : ScriptableObject
        {
            index.ValidateEditor();
            foreach (var guid in AssetDatabase.FindAssets($"t:{typeof(T).Name}"))
            {
                var config = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
                if (!config.IsNull())
                {
                    index.Validate(config);
                }
            }
        }
    }
}