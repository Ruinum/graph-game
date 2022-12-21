using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class DirectionDistancePointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy DistanceStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy SourcePointStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy DirectionStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!DistanceStrategy.TryGet(entity, out var distance))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(distance), (nameof(entity), entity));
                return false;
            }

            if (!DirectionStrategy.TryGet(entity, out var direction))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity), (nameof(distance), distance));
                return false;
            }

            if (!SourcePointStrategy.TryGet(entity, out var sourcePoint))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(sourcePoint), (nameof(entity), entity), (nameof(distance), distance), (nameof(direction), direction));
                return false;
            }

            result = sourcePoint + direction * distance;
            return true;
        }
    }
}