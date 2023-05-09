using Ruinum.ECS.Core.Systems;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Assets;
using Ruinum.ECS.Systems.Audio;
using Ruinum.ECS.Systems.Destroy;
using Ruinum.ECS.Systems.Features.Destroy;
using Ruinum.ECS.Systems.Game;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class RuinumSystems : Feature
    {
        public RuinumSystems(Contexts contexts, IGameServices services)
        {
            Add(new ServicesInitializeSystem(contexts, services));
            Add(new RootCanvasInitializeSystem());
            Add(new NextFrameDestroySystem(contexts.game));
            Add(new RootOwnerSystem(contexts.game));
            Add(new InputSystems(contexts, services));
            Add(new TimeSystems(contexts, services));

            Add(new GameSystems(contexts, services));
            Add(new StateSystems(contexts, services));
            Add(new PrefabSystems(contexts, services));
            Add(new AudioSystem(contexts.game, services.Audio));

            Add(new SceneSystems(contexts, services));

            Add(new DestroySystems(contexts, services));

            Add(new EventSystems(contexts));
            Add(new DestroyDestroyedSystem(contexts));
        }
    }
}