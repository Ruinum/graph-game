using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class PointsDistanceByAxisValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy First;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Second;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3Axis Axis = Vector3Axis.Y;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public bool Absolute = true;

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

            value = VectorUtilities.GetAxisValue(Axis, firstPoint) - VectorUtilities.GetAxisValue(Axis, secondPoint);
            if (Absolute)
            {
                value = Mathf.Abs(value);
            }
            return true;
        }
    }
}