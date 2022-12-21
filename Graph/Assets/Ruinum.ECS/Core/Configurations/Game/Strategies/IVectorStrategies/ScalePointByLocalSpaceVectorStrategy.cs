using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ScalePointByLocalSpaceVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy ScaleVector;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy PointStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy LocalSpaceTarget;
 
        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!LocalSpaceTarget.TryGet(entity, out var localSpaceTarget))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(localSpaceTarget), (nameof(entity), entity));
                return false;
            }

            if (!ScaleVector.TryGet(entity, out var scale))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(scale), (nameof(entity), entity), (nameof(localSpaceTarget), localSpaceTarget));
                return false;
            }

            if (!localSpaceTarget.TryGetRootPositionRotation(out var position, out var rotation))
            {
                result = default;
                if (Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(localSpaceTarget), localSpaceTarget), (nameof(scale), scale));
                return false;
            }

            if (!PointStrategy.TryGet(entity, out var point))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(localSpaceTarget), localSpaceTarget), (nameof(scale), scale), (nameof(position), position), (nameof(rotation), rotation));
                return false;
            }

            var localPoint = point.InverseTransformPoint(position, rotation);
            localPoint.Scale(scale);
            if (localPoint == Vector3.zero)
            {
                localPoint = scale;
            }
            result = localPoint.TransformPosition(position, rotation);
            return true;
        }
    }
}