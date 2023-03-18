using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class SetAxisValueVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3Axis Axis;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Vector;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Value;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
                return false;
            }

            if (!Value.TryGet(entity, out var value))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity), (nameof(vector), vector));
                return false;
            }

            result = VectorUtilities.SetAxisValue(Axis, vector, value);
            return true;
        }
    }
}