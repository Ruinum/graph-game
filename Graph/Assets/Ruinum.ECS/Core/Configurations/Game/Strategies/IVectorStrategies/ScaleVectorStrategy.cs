using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ScaleVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Scale;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
                return false;
            }

            if (!Scale.TryGet(entity, out var scale))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(scale), (nameof(entity), entity), (nameof(vector), vector));
                return false;
            }

            result = vector.GetScaled(scale);
            return true;
        }
    }
}