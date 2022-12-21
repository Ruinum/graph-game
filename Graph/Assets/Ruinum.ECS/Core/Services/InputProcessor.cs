using System;
using System.Collections.Generic;
using Ruinum.ECS.Configurations.Conditions.Input;
using Ruinum.ECS.Core.Systems.Log;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ruinum.ECS.Services
{
    public sealed class InputProcessor
    {      
        private readonly InputActionAsset _asset;
        private readonly Dictionary<string, ActionMap> _maps = new Dictionary<string, ActionMap>();
        
        public InputProcessor(InputActionAsset asset)
        {
            _asset = asset;
            foreach (var map in asset.actionMaps)
            {
                _maps.Add(map.name, new ActionMap(map, map.actions));
                Debug.LogWarning(map.name);
            }
        }

        public void SwitchInputActionMap(string name)
        {
            foreach (var (mapName, actionMap) in _maps)
            {
                if (mapName == name)
                {
                    actionMap.Enable();
                }
            }
        }

        public bool IsButtonInteracted(string mapName, string actionName, InputButtonInteractType interaction)
        {            
            return GetMap(mapName).IsButtonInteracted(actionName, interaction);
        }

        public T ReadValue<T>(string mapName, string actionName) where T : struct =>
            GetMap(mapName).ReadValue<T>(actionName);

        private ActionMap GetMap(string mapName)
        {
            if (_maps.TryGetValue(mapName, out var map))
            {
                return map;
            }
            foreach(var item in _maps.Values)
            {
                Debug.Log(item);
            }
            LogExtention.Error($"Action map {mapName} not found");
            return default;
        }
    }
}