using Ruinum.ECS.Configurations.Conditions.Input;
using Ruinum.ECS.Core.Systems.Log;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Ruinum.ECS.Services
{
    public sealed class ActionMap
    {
        private readonly InputActionMap _actionMap;
        private readonly Dictionary<string, ActionMapAction> _actions = new Dictionary<string, ActionMapAction>();

        public ActionMap(InputActionMap actionMap, ReadOnlyArray<InputAction> actions)
        {
            _actionMap = actionMap;
            foreach (var action in actions)
            {
                _actions.Add(action.name, new ActionMapAction(action));
            }
        }

        public void Enable()
        {
            _actionMap.Enable();
        }

        public void Disable()
        {
            _actionMap.Disable();
        }
        
        public bool IsButtonInteracted(string actionName, InputButtonInteractType interaction)
        {
            switch (interaction)
            {
                case InputButtonInteractType.Down:
                    return IsButtonDown(actionName);
                case InputButtonInteractType.Hold:
                    return IsButtonHold(actionName);
                default:
                    LogExtention.Error($"Interaction [{interaction.ToString()}] is not supported");
                    return false;
            }
        }

        public T ReadValue<T>(string actionName) where T : struct =>
            GetAction(actionName).ReadValue<T>();

        private ActionMapAction GetAction(string actionName)
        {
            if (_actions.TryGetValue(actionName, out var action))
            {
                return action;
            }
            LogExtention.Error($"Action {actionName} not found");
            return default;
        }

        private bool IsButtonDown(string actionName) =>
            GetAction(actionName).IsButtonDown();

        private bool IsButtonHold(string actionName) =>
            GetAction(actionName).IsButtonHold();
    }
}