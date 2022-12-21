using UnityEngine.InputSystem;

namespace Ruinum.ECS.Services
{
    public sealed class ActionMapAction
    {
        private readonly InputAction _action;

        public ActionMapAction(InputAction action) =>
            _action = action;

        public bool IsButtonDown() =>
            _action.WasPerformedThisFrame();

        public bool IsButtonHold() =>
            _action.IsPressed();

        public T ReadValue<T>() where T : struct =>
            _action.ReadValue<T>();
    }
}