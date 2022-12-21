using Ruinum.ECS.Configurations.Conditions.Input;

namespace Ruinum.ECS.Services.Interfaces
{
    public interface IInputService : IInitializableService
    {
        float GetMouseAxisX();

        float GetMouseAxisY();

        float GetPlayerMoveX();

        float GetPlayerMoveY();

        bool IsButtonInteracted(string map, string buttonName, InputButtonInteractType interaction);

        void SetAxisMap(string mapName);
        
        void SetMap(string mapName);
    }
}