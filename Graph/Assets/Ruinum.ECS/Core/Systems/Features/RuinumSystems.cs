using Ruinum.ECS.Core.Systems;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Assets;
using Ruinum.ECS.Systems.Prefab;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class RuinumSystems : Feature
    {
        public RuinumSystems(Contexts contexts, IGameServices services)
        {
            Add(new ServicesInitializeSystem(contexts, services));

            Add(new SceneSystems(contexts, services));

            Add(new PrefabSystem(contexts.game, services.Asset));

            Add(new GameSystems(contexts, services));
            
            Add(new RootOwnerSystem(contexts.game));
            Add(new EventSystems(contexts));

            Add(new StartTimeSystem(contexts.game));
            Add(new TimeSystem(contexts.game));

            Add(new NextFrameDestroySystem(contexts.game));
            Add(new DestroySystem(contexts.game));
        }
    }
}