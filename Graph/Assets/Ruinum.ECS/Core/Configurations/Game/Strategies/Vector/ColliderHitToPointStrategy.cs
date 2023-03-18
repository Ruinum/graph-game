using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ColliderHitToPointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            //if (!TargetStrategy.TryGet(entity, out var target))
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
            //    return false;
            //}

            //if (!target.hasColliderHit)
            //{
            //    result = default;
            //    if(Logging) LogErrorNotFound("ColliderHitComponent", (nameof(entity), entity), (nameof(target), target));
            //    return false;
            //}

            //result = target.colliderHit.Value.Point;
            result = default;
            return true;
        }
    }
}