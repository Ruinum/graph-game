using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class PointOffsetStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy PointStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy OffsetStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!PointStrategy.TryGet(entity, out var point))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity));
                return false;
            }

            if (!OffsetStrategy.TryGet(entity, out var offset))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(offset), (nameof(entity), entity), (nameof(point), point));
                return false;
            }

            result = point + offset;
            return true;
        }
    }
}