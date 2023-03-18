using Ruinum.ECS.Configurations.Game.Strategies.Layers;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class RaycastHitOrDistancePointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ILayerMaskStrategy LayerMask;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy DistanceStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy DirectionStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy SourcePointStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!LayerMask.TryGet(entity, out var mask))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(mask), (nameof(entity), entity));
                return false;
            }

            if (!DistanceStrategy.TryGet(entity, out var distance))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(distance), (nameof(entity), entity), (nameof(mask), mask));
                return false;
            }

            if (!DirectionStrategy.TryGet(entity, out var direction))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity), (nameof(mask), mask), (nameof(distance), distance));
                return false;
            }

            if (!SourcePointStrategy.TryGet(entity, out var sourcePoint))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(sourcePoint), (nameof(entity), entity), (nameof(mask), mask), (nameof(distance), distance), (nameof(direction), direction));
                return false;
            }

            result = Physics.Raycast(sourcePoint, direction, out var hit, distance, mask) ? hit.point : sourcePoint + direction * distance;
            return true;
        }
    }
}