using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Systems.Assets
{
    public sealed class SceneSystems : Feature
    {
        public SceneSystems(Contexts contexts, IGameServices services)
        {
            Add(new LoadAssetsByLabelSystem(contexts.game, services.Asset));
            Add(new UnloadAssetsByLabelSystem(contexts.game, services.Asset));         
        }
    }
}