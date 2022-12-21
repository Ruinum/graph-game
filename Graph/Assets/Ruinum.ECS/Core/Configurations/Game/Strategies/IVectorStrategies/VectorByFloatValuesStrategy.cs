using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VectorByFloatValuesStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy X;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Y;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Z;
        [LabelWidth(EditorConstants.SmallLabelWidth)] private Vector3 _buffer = Vector3.zero;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!X.TryGet(entity, out var xValue))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(xValue), (nameof(entity), entity));
                return false;
            }

            if (!Y.TryGet(entity, out var yValue))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(yValue), (nameof(entity), entity), (nameof(xValue), xValue));
                return false;
            }

            if (!Z.TryGet(entity, out var zValue))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(zValue), (nameof(entity), entity), (nameof(xValue), xValue), (nameof(yValue), yValue));
                return false;
            }

            _buffer.Set(xValue, yValue, zValue);
            result = _buffer;
            return true;
        }
    }
}