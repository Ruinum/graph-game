using Ruinum.ECS.Constants;
using Ruinum.Editor.Validation;

using System.Collections;

using TMPro.EditorUtilities;

using UnityEditor;

using Object = System.Object;

namespace Ruinum.Editor
{
    public static class FinalizeProjectEditor
    {
        [MenuItem(EditorConstants.RootMenuName + "/Finalize", false, EditorConstants.MenuLowPriority)]
        public static void FinalizeProject()
        {
            TMP_EditorCoroutine.StartCoroutine(Run());
        }

        private static IEnumerator Run()
        {
            var progressId = Progress.Start("Running one task");
            yield return null;
            ValidationEditor.ValidateConfigIndexes();
            yield return null;
            AssetDatabase.SaveAssets();
            Progress.Finish(progressId);
        }           
    }
}