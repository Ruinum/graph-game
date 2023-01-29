using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ruinum.ECS.Services
{
    public sealed class ConfigService : IConfigService
    {
        public GameConfig SharedConfig { get; private set; }
        private IConfigIndex<GameEntityConfig> _configIndex;

        public static async Task<T> LoadConfig<T>(string key) where T : ScriptableObject
        {
            var configOperation = Addressables.LoadAssetAsync<T>(key);
            var config = await configOperation.Task;
#if UNITY_EDITOR
            if (configOperation.Status == AsyncOperationStatus.Failed)
            {
                config = CreateAsset<T>(key);
            }
#endif
            return config;
        }

        private static async Task<GameConfigIndex> LoadConfigIndex() =>
            await LoadConfig<GameConfigIndex>(AddressablesConstants.GameConfigIndexAssetName);

        private static async Task<GameConfig> LoadSharedConfigAsync() =>
            await LoadConfig<GameConfig>(AddressablesConstants.GameConfigAssetName);

        public GameEntityConfig GetConfig(int index) =>
            _configIndex.GetConfig(index);

        public async Task PostInitializeAsync() =>
            await Task.CompletedTask;

        public async Task PreInitializeAsync()
        {
            SharedConfig = await LoadSharedConfigAsync();
            _configIndex = await LoadConfigIndex();
        }

#if UNITY_EDITOR
        public static GameConfig LoadSharedConfigEditor() =>
            LoadAssetEditor<GameConfig>(AddressablesConstants.GameConfigAssetName);

        public static GameConfigIndex LoadConfigIndexEditor() =>
            LoadAssetEditor<GameConfigIndex>(AddressablesConstants.GameConfigIndexAssetName);

        public static ComponentDataContainerConfigIndex LoadComponentDataContainerConfigIndexEditor() =>
           LoadAssetEditor<ComponentDataContainerConfigIndex>(AddressablesConstants.ComponentDataContainerConfigIndexAssetName);

        private static T LoadAssetEditor<T>(string key) where T : ScriptableObject
        {
            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
            var allEntries = new List<UnityEditor.AddressableAssets.Settings.AddressableAssetEntry>(settings.groups.SelectMany(g => g.entries));
            var foundEntry = allEntries.FirstOrDefault(e => e.address == key);
            return foundEntry != null ? UnityEditor.AssetDatabase.LoadAssetAtPath<T>(foundEntry.AssetPath) : null;
        }

        private static T CreateAsset<T>(string key) where T : ScriptableObject
        {
            var config = ScriptableObject.CreateInstance<T>();
            var configName = typeof(T).Name;
            var path = $"{PathConstants.AssetsPath}{configName}.asset";
            UnityEditor.AssetDatabase.CreateAsset(config, path);

            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
            var entry = settings.CreateOrMoveEntry(UnityEditor.AssetDatabase.AssetPathToGUID(path), settings.DefaultGroup);
            entry.address = key;
            settings.SetDirty(UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.ModificationEvent.EntryMoved, entry, true);

            LogExtention.Warning($"{config.name} created at path: {path}");

            return config;
        }
#endif
    }
}