using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ScaleDirectionByLocalSpaceVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.LargeLabelWidth)] public VectorStrategy ScaleVector;
        [LabelWidth(EditorConstants.LargeLabelWidth)] public VectorStrategy DirectionStrategy;
        [LabelWidth(EditorConstants.LargeLabelWidth)] public TargetStrategy LocalSpaceTarget;

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

            if (!DirectionStrategy.TryGet(entity, out var point))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(localSpaceTarget), localSpaceTarget), (nameof(scale), scale), (nameof(position), position), (nameof(rotation), rotation));
                return false;
            }

            var localDirection = point.InverseTransformDirection(position, rotation);
            localDirection.Scale(scale);
            if (localDirection == Vector3.zero)
            {
                localDirection = scale;
            }
            result = localDirection.TransformDirection(position, rotation);
            return true;
        }
    }
}