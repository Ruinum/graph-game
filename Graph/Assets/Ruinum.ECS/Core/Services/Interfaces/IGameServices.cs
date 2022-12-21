namespace Ruinum.ECS.Services.Interfaces
{
    public interface IGameServices
    {
        IConfigService Config { get; }
        IAssetService Asset { get; }
        IEntityIndexService EntityIndex { get; }
        IInputService Input { get; }
    }
}