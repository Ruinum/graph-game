using Ruinum.ECS.Configurations.Game.Strategies.Rotation;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class RotationSpacePointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Position;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public RotationStrategy Rotation;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Point;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Rotation.TryGet(entity, out var rotation))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(rotation), (nameof(entity), entity));
                return false;
            }

            if (!Position.TryGet(entity, out var position))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(position), (nameof(entity), entity), (nameof(rotation), rotation));
                return false;
            }

            if (!Point.TryGet(entity, out var point))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(rotation), rotation), (nameof(position), position));
                return false;
            }

            result = point.TransformPosition(position, rotation);
            return true;
        }
    }
}