using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public class GameObjectInOwnerHierarchyTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            return entity.TryGetOwnerByComponentInOwnerHierarchy<GameObjectComponent>(GameComponentsLookup.GameObject, out targetEntity);
        }
    }
}