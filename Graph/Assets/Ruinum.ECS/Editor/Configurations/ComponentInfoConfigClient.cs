using System;
using System.Collections.Generic;
using System.Linq;

using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Editor.Constants;

using UnityEditor;
using UnityEngine;


namespace Ruinum.ECS.Editor.Configurations
{
    public sealed class ComponentInfoConfigClient 
    {
        public static ComponentInfoConfigClient Instance => _instance ?? (_instance = Create());
        private static ComponentInfoConfigClient _instance;
        private static readonly Type[] ConfigTypes  = { typeof(GameComponentInfoConfig)};
        private readonly Dictionary<Type, ComponentInfoConfig> _configs = new Dictionary<Type, ComponentInfoConfig>();

        public static ComponentInfoConfigClient Create()
        {
            return new ComponentInfoConfigClient();
        }

        private ComponentInfoConfigClient()
        {
            var assets = AssetUtilities.GetAssetsInFolder<ComponentInfoConfig>(AssetPathsConstants.ComponentInfoAssetFolder);
            for (int i = 0, max = ConfigTypes.Length; i < max; i++)
            {
                var configType = ConfigTypes[i];
                var asset = assets.FirstOrDefault(m => !m.IsNull() && m.GetType() == configType) ?? CreateComponentInfoConfig(configType);
                _configs.Add(asset.EntityType, asset);
            }
        }

        private ComponentInfoConfig CreateComponentInfoConfig(Type type)
        {
            var config = (ComponentInfoConfig) ScriptableObject.CreateInstance(type);
            var path = AssetPathsConstants.ComponentInfoAssetFolderPath + type.Name + AssetPathsConstants.AssetExtension;
            AssetDatabase.CreateAsset(config, path);
            LogExtention.Warning($"ComponentInfoConfig of type [{type.Name}] created at path: {path}");
            return config;
        }

        public string GetComponentInfo(Type entityType, int index)
        {
            if (_configs.ContainsKey(entityType))
            {
                return _configs[entityType].GetInfo(index);
            }
            LogExtention.Error($"ComponentInfoConfig of EntityType [{entityType.Name}] not found");
            return string.Empty;
        }
    }
}