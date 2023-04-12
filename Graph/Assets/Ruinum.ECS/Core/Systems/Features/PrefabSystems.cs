using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Game;
using Ruinum.ECS.Systems.Game.Subscribers;
using Ruinum.ECS.Systems.Prefab;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class PrefabSystems : Feature
    {
        public PrefabSystems(Contexts contexts, IGameServices services)
        {
            Add(new PrefabSystem(contexts.game, services.Asset));
            Add(new GameOwnerTransformChildSystem(contexts.game));
            Add(new TransformChildByConfigSystem(contexts.game, services.EntityIndex));
            Add(new ColorPublisherSubscriberSystem(contexts.game));
            Add(new MeshSystem(contexts.game, services.Asset));
        }
    }
}