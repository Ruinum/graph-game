using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Services
{
    public sealed class RuinumServices : IGameServices
    {
        public IConfigService Config { get; }
        public IAssetService Asset { get; }
        public ILoaderService Loader { get; }
        public IEntityIndexService EntityIndex { get; }
        public ISceneService SceneService { get; }
        public IInputService Input { get; }
        
        public RuinumServices(IConfigService config,
            IAssetService asset, IEntityIndexService entityIndex, ILoaderService loaderService, ISceneService sceneService, IInputService input)
        {
            Loader = loaderService;
            Config = config;
            Asset = asset;
            EntityIndex = entityIndex;
            SceneService = sceneService;
            Input = input;
        }
    }
}