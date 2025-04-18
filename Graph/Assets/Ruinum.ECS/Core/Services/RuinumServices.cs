﻿using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Services
{
    public sealed class RuinumServices : IGameServices
    {
        public IConfigService Config { get; }
        public IAssetService Asset { get; }
        public IAudioService Audio { get; }
        public ILoaderService Loader { get; }
        public IEntityIndexService EntityIndex { get; }
        public ISceneService Scene { get; }
        public IInputService Input { get; }

        public RuinumServices(IConfigService config,
            IAssetService asset, IEntityIndexService entityIndex, ILoaderService loaderService, ISceneService sceneService, IInputService input, IAudioService audio)
        {
            Loader = loaderService;
            Config = config;
            Asset = asset;
            EntityIndex = entityIndex;
            Scene = sceneService;
            Input = input;
            Audio = audio;
        }
    }
}