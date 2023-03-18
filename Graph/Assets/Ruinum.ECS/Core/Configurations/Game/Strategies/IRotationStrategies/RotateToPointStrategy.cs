using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class RotateToPointStrategy : RotationStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 UpwardVector = Vector3.up;

        public override bool TryGet(GameEntity entity, out Quaternion rotation)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                rotation = default;
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasPoint)
            {
                rotation = default;
                if (Logging) LogErrorNotFound("PointComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                rotation = default;
                if (Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            rotation = Quaternion.LookRotation(target.point.Value - position, UpwardVector);
            return true;
        }
    }
}