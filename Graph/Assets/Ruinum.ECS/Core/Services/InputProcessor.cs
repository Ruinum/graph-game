using System.Collections.Generic;
using Ruinum.ECS.Configurations.Conditions.Input;
using Ruinum.ECS.Core.Systems.Log;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ruinum.ECS.Services
{
    public sealed class InputProcessor
    {
        public InputActionAsset Asset { get; }

        private const string CheatsMap = "Cheats"; // TODO: Cheats map
        private const string BindingsKey = nameof(BindingsKey);
        private readonly Dictionary<string, ActionMap> _maps = new Dictionary<string, ActionMap>();

        public InputProcessor(InputActionAsset asset)
        {
            Asset = asset;
            foreach (var map in asset.actionMaps)
            {
                _maps.Add(map.name, new ActionMap(map, map.actions));
            }
        }

        public void Enable() =>
            Asset.Enable();

        public void Initialize()
        {
            if (PlayerPrefs.HasKey(BindingsKey))
            {
                Asset.LoadBindingOverridesFromJson(PlayerPrefs.GetString(BindingsKey));
            }
        }

        public bool IsButtonInteracted(string mapName, string actionName, InputButtonInteractType interaction) =>
            GetMap(mapName).IsButtonInteracted(actionName, interaction);

        public T ReadValue<T>(string mapName, string actionName) where T : struct =>
            GetMap(mapName).ReadValue<T>(actionName);

        public void Save() =>
            PlayerPrefs.SetString(BindingsKey, Asset.SaveBindingOverridesAsJson());

        public void SwitchInputActionMap(string name)
        {
            foreach (var map in _maps)
            {
                if (map.Key == name)
                {
                    map.Value.Enable();
                }
                else if (map.Key != CheatsMap)
                {
                    map.Value.Disable();
                }
            }
        }

        private ActionMap GetMap(string mapName)
        {
            if (_maps.TryGetValue(mapName, out var map))
            {
                return map;
            }
            LogExtention.Error($"Action map {mapName} not found");
            return default;
        }

        public void Reset()
        {
            foreach (var map in Asset.actionMaps)
            {
                map.RemoveAllBindingOverrides();
            }

            PlayerPrefs.DeleteKey(BindingsKey);
        }
    }
}