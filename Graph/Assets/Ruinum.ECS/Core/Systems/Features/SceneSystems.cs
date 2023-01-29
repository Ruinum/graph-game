using Ruinum.ECS.Core.Systems;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Scenes;

namespace Ruinum.ECS.Systems.Assets
{
    public sealed class SceneSystems : Feature
    {
        public SceneSystems(Contexts contexts, IGameServices services)
        {
            Add(new LoadAssetsByLabelSystem(contexts.game, services.Asset));
            Add(new UnloadAssetsByLabelSystem(contexts.game, services.Asset));

            Add(new LoadSceneSystem(contexts.game, services.Scene));
            Add(new CheckSceneLoadedSystem(contexts.game));
            Add(new CheckScenesLoadingSystem(contexts.game, services.Loader));
            Add(new CheckScenesStatusSystem(contexts.game, services.Loader));
            Add(new CleanLoadedSceneSystem(contexts.game));
        }
    }
}