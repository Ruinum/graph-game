using Entitas;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Services.Index;

namespace Ruinum.ECS.Systems
{
    public sealed class RootOwnerSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly GameContext _context;
        
        public RootOwnerSystem(GameContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.GetGroup(GameMatcher.Owner).OnEntityAdded += OnOwnerAdded;
        }
        
        private static void OnOwnerAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            var ownerComponent = (OwnerComponent) component;
            entity.SetOwner(ownerComponent.Value);
            ReplaceRootOwner(entity.GetRootOwner(), entity);
        }

        private static void ReplaceRootOwner(GameEntity rootOwner, GameEntity entity)
        {
            entity.SetRootOwner(rootOwner);
            entity.ReplaceRootOwner(rootOwner);
            entity.isDestroyed = entity.HasComponentInOwnerHierarchy(GameComponentsLookup.Destroyed);
            if (!entity.HasConfigIndexCached)
            {
                return;
            }
            entity.AddOwnerEntityConfigIndexKey(new RootOwnerConfigIndexer.Key{ConfigIndex = entity.ConfigIndexCached, Entity = rootOwner});
        }

        public void TearDown()
        {
            _context.GetGroup(GameMatcher.Owner).OnEntityAdded -= OnOwnerAdded;
        }
    }
}