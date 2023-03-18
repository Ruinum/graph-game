using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class PointsDistanceValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy First;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Second;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!First.TryGet(entity, out var firstPoint))
            {
                value = default;
                if (Logging) LogErrorNotFound(nameof(firstPoint), (nameof(entity), entity));
                return false;
            }

            if (!Second.TryGet(entity, out var secondPoint))
            {
                value = default;
                if (Logging) LogErrorNotFound(nameof(secondPoint), (nameof(entity), entity), (nameof(firstPoint), firstPoint));
                return false;
            }

            value = Vector3.Distance(firstPoint, secondPoint);
            return true;
        }
    }
}