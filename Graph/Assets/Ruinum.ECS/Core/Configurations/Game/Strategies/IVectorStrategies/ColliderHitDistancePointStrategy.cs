using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ColliderHitDistancePointStrategy : VectorStrategy
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

            //var hit = target.colliderHit.Value;
            //result = hit.SourcePoint + hit.Direction * hit.Distance;
            result = default;
            return true;
        }
    }
}