using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VectorSumStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy FirstVector;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy SecondVector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!FirstVector.TryGet(entity, out var first))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
                return false;
            }

            if (!SecondVector.TryGet(entity, out var second))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
                return false;
            }

            result = first + second;
            return true;
        }
    }
}