using Ruinum.ECS.Configurations.Game;


namespace Ruinum.ECS.Services.Interfaces
{
    public interface IConfigService : IInitializableService
    {
        GameConfig SharedConfig { get; }

        GameEntityConfig GetConfig(int index);
    }
}