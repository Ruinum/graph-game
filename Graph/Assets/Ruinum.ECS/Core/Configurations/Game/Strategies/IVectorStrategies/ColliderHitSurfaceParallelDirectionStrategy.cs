using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ColliderHitSurfaceParallelDirectionStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy DirectionStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            //if (!entity.hasColliderHit)
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound("ColliderHitComponent", (nameof(entity), entity));
            //    return false;
            //}

            //if (!DirectionStrategy.TryGet(entity, out var direction))
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity));
            //    return false;
            //}

            //result = VectorUtilities.GetSurfaceParallel(entity.colliderHit.Value.Normal, direction);
            result = default;
            return true;
        }
    }
}