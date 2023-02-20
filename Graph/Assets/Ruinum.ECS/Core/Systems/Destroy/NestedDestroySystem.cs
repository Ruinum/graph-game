using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Systems.Destroy
{
    public sealed class NestedDestroyedSystem : ISystem
    {        
        private readonly EntityIndex<GameEntity, GameEntity> _ownerIndex;
        
        
        public NestedDestroyedSystem(IContext<GameEntity> gameContext)
        {
            gameContext.GetGroup(GameMatcher.Destroyed).OnEntityAdded+= OnOnEntityAdded;
            _ownerIndex = (EntityIndex<GameEntity, GameEntity>) gameContext.GetEntityIndex(Contexts.Owner);
        }

        private void OnOnEntityAdded(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            Execute(entity);
        }
        
        private void Execute(GameEntity e)
        {
            Destroy(_ownerIndex.GetEntities(e));
        }

        private void Process(GameEntity e)
        {
            e.isDestroyed = true;
            Destroy(_ownerIndex.GetEntities(e));
        }

        private void Destroy(HashSet<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Process(gameEntity);
            }
        }
    }
}