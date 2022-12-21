using System.Collections.Generic;
using System.Linq;

using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Unity.Editor;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.Editor.Validation;

using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

using UnityEditor;
using UnityEngine;


namespace Ruinum.ECS.Editor.Validation
{
    public sealed class ReferenceValidationEditor : OdinEditorWindow
    {
        [PropertyOrder(2), ListDrawerSettings(IsReadOnly = true, Expanded = true, NumberOfItemsPerPage = 25)]
        public readonly List<(string path, Object obj)> Used = new List<(string, Object)>();

        [MenuItem(EditorConstants.RootMenuValidationPath + "Config references")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(ReferenceValidationEditor));
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
        }

        [PropertyOrder(1), Button(ButtonSizes.Medium), GUIColor(0, 1, 0)]
        public void Validate()
        {
            Used.Clear();
            var tree = new ConfigTree();
            tree.Build();
            foreach (var parent in tree.NullPath)
            {
                if (tree.Objects.TryGetValue(parent.obj, out var values))
                {
                    var parentOfParent = values.First();
                    var path = parentOfParent.path + "/" + parent.path;
                    Used.Add((path, tree.GetConfig(parentOfParent.obj, ref path)));
                }                
            }
        }

        public static void ValidateLog()
        {
            var tree = new ConfigTree();
            tree.Build();
            foreach (var parent in tree.NullPath)
            {
                var parentOfParent = tree.Objects[parent.obj].First();
                var path = parentOfParent.path + "/" +  parent.path;
                var config = tree.GetConfig(parentOfParent.obj, ref path);
                LogExtention.Error($"Field [{path}] in [{config.name}] is null or empty\n{config.AssetPath()}");
            }
        }
    }
}