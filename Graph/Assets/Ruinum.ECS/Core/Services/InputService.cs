using Ruinum.ECS.Configurations.Conditions.Input;
using Ruinum.ECS.Services.Interfaces;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ruinum.ECS.Services
{
    public sealed class InputService : IInputService
    {
        private const string MoveAxis = "Move";
        private const string LookAxis = "Look";
        private readonly InputProcessor _processor;
        private string _axisMapName;

        public InputService(InputActionAsset input) =>
            _processor = new InputProcessor(input);

        public InputActionAsset GetActionAsset() =>
            _processor.Asset;

        public float GetMouseAxisX() =>
            GetAxisInteracted(LookAxis).x;

        public float GetMouseAxisY() =>
            GetAxisInteracted(LookAxis).y;

        public float GetPlayerMoveX() =>
            GetAxisInteracted(MoveAxis).x;

        public float GetPlayerMoveY() =>
            GetAxisInteracted(MoveAxis).y;

        public bool IsButtonInteracted(string mapName, string buttonName, InputButtonInteractType interaction) =>
            _processor.IsButtonInteracted(mapName, buttonName, interaction);

        public async Task PostInitializeAsync() =>
            await Task.CompletedTask;

        public async Task PreInitializeAsync()
        {
            _processor.Initialize();
            _processor.Enable();
            await Task.CompletedTask;
        }

        public void Reset() =>
            _processor.Reset();

        public void Save() =>
            _processor.Save();

        public void SetAxisMap(string axisMapName) =>
            _axisMapName = axisMapName;

        public void SetMap(string mapName) =>
            _processor.SwitchInputActionMap(mapName);

        private Vector2 GetAxisInteracted(string axisName) =>
            _processor.ReadValue<Vector2>(_axisMapName, axisName);
    }
}