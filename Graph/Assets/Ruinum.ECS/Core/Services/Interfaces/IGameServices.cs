namespace Ruinum.ECS.Services.Interfaces
{
    public interface IGameServices
    {
        IConfigService Config { get; }
        IAssetService Asset { get; }
        IAudioService Audio { get; }
        ILoaderService Loader { get; }
        IEntityIndexService EntityIndex { get; }
        ISceneService Scene { get; }
        IInputService Input { get; }
    }
}