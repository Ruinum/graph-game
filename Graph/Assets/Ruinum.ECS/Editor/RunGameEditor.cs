using Ruinum.ECS.Constants;
using Ruinum.ECS.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ruinum.Editor
{
    public static class RunGameEditor
    {
        private const string LoadSceneName = nameof(LoadSceneName);

        [MenuItem(EditorConstants.RootMenuPath + "Run Game %q", false, EditorConstants.RunGameEditorRunGamePriority)]
        public static void RunGame()
        {
            if (EditorApplication.isPlaying)
            {
                return;
            }
            PlayerPrefs.SetString(LoadSceneName, SceneManager.GetActiveScene().name);
            if (!SceneManager.GetActiveScene().name.Equals(SceneConstants.Initialize))
            {
                EditorUtilities.OpenScene(SceneConstants.Initialize);
            }
            EditorApplication.isPlaying = true;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange mode)
        {
            if (mode != PlayModeStateChange.EnteredEditMode || !PlayerPrefs.HasKey(LoadSceneName))
            {
                return;
            }
            var sceneName = PlayerPrefs.GetString(LoadSceneName);
            if (!sceneName.Equals(SceneManager.GetActiveScene().name))
            {
                EditorUtilities.OpenScene(sceneName);
            }
            PlayerPrefs.DeleteKey(LoadSceneName);
        }
    }
}