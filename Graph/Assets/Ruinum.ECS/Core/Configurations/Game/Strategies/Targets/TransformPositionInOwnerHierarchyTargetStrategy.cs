using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public class TransformPositionInOwnerHierarchyTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            return entity.TryGetOwnerByComponentInOwnerHierarchy<TransformPositionComponent>(GameComponentsLookup.TransformPosition, out targetEntity);
        }
    }
}