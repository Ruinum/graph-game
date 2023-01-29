using Ruinum.ECS.Core.Systems;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Assets;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class RuinumSystems : Feature
    {
        public RuinumSystems(Contexts contexts, IGameServices services)
        {
            Add(new ServicesInitializeSystem(contexts, services));
            Add(new NextFrameDestroySystem(contexts.game));
            Add(new RootOwnerSystem(contexts.game));
            Add(new InputSystems(contexts, services));
            Add(new TimeSystems(contexts, services)); 
            
            Add(new GameSystems(contexts, services));
            Add(new PrefabSystems(contexts, services));
            
            Add(new SceneSystems(contexts, services));

            Add(new DestroySystem(contexts.game));
            Add(new EventSystems(contexts));
        }
    }
}