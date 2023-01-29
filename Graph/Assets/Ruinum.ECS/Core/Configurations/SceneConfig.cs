using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Ruinum.ECS.Core.Configurations
{
    [CreateAssetMenu(menuName = EditorConstants.RootMenuConfigPath + nameof(SceneConfig), fileName = nameof(SceneConfig), order = EditorConstants.MenuHighestPriority)]
    public class SceneConfig : SerializedScriptableObject
    {
        public AssetReference Reference;
        public LoadSceneMode LoadMode = LoadSceneMode.Single;
        public AssetReference[] AdditionalScenes = new AssetReference[0];
    }
}