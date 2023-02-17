using Ruinum.ECS.Parsers;
using UnityEditor;
using UnityEditor.SceneManagement;


namespace Ruinum.ECS.Editor
{
    public static class EditorUtilities
    {
        public static void OpenScene(string sceneName, OpenSceneMode mode = OpenSceneMode.Single)
        {
            OpenSceneFromBuildSettings(sceneName, mode);
            var parser = new LevelSceneNameParser(sceneName);
            if (parser.IsLevelScene())
            {
                foreach (var name in parser.AdditionalSceneNames)
                {
                    OpenSceneFromBuildSettings(name, OpenSceneMode.Additive);
                }
            }
        }

        private static void OpenSceneFromBuildSettings(string sceneName, OpenSceneMode mode)
        {
            EditorSceneManager.OpenScene(
                AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("t:SceneAsset " + sceneName, new [] {"Assets"})[0]), mode);
        }
    }
}
