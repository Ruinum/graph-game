using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class PositionToColliderHitDirectionPointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 PositionScaleVector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            //if (!entity.hasColliderHit)
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound("ColliderHitComponent", (nameof(entity), entity));
            //    return false;
            //}

            //if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity));
            //    return false;
            //}

            //var colliderHit = entity.colliderHit.Value;
            //var scaledPosition = position.GetScaled(PositionScaleVector);
            //var scaledColliderHitPoint = colliderHit.Point.GetScaled(PositionScaleVector);
            //var distance = Vector3.Distance(scaledPosition, scaledColliderHitPoint);
            //result = position + (scaledColliderHitPoint - scaledPosition).normalized * distance;
            result = default;
            return true;
        }
    }
}