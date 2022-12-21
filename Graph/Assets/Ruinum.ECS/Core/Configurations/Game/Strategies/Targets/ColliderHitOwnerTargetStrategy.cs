using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ColliderHitOwnerTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            //if (!entity.hasColliderHit)
            //{
            //    targetEntity = default;
            //    if(Logging) LogErrorNotFound("ColliderHitComponent", (nameof(entity), entity));
            //    return false;
            //}
            //var collider = entity.colliderHit.Value.Collider;
            //if (collider.IsNull())
            //{
            //    targetEntity = default;
            //    if(Logging) LogError("Collider in ColliderHitComponent is empty.", (nameof(entity), entity));
            //    return false;
            //}

            //var entityBehaviour = collider.transform.root.GetComponent<GameEntityBehaviour>();
            //if (entityBehaviour.IsNull())
            //{
            //    entityBehaviour = collider.transform.GetComponent<GameEntityBehaviour>();
            //    if (entityBehaviour.IsNull())
            //    {
            //        var behaviours = collider.transform.GetComponentsInParent<GameEntityBehaviour>();
            //        if (behaviours == null || behaviours.Length == 0)
            //        {
            //            targetEntity = default;
            //            if (Logging) LogError("GameEntityBehaviour is absent.", (nameof(entity), entity));
            //            return false;
            //        }
            //        entityBehaviour = behaviours[0];
            //    }
            //}

            //if (entityBehaviour.Entity == null)
            //{
            //    if (Logging) LogError("entityBehaviour entity is null.", (nameof(entity), entity), (nameof(entityBehaviour), entityBehaviour.name));
            //    targetEntity = default;
            //    return false;
            //}
            //targetEntity = entityBehaviour.Entity;
            //return true;
            targetEntity = null;
            return true;
        }
    }
}