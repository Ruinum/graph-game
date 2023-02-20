using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Destroy;

namespace Ruinum.ECS.Systems.Features.Destroy
{
    public sealed class DestroySystems : Feature
    {
        public DestroySystems(Contexts contexts, IGameServices services)
        {
            Add(new NestedDestroyedSystem(contexts.game));
            Add(new DestroyedSystem(contexts.game));

            Add(new CreatorDestroySystem(contexts.game));
            Add(new TargetDestroySystem(contexts.game));
            Add(new CreatedEntityDestroySystem(contexts.game));
        }
    }
}