using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VectorSumByDeltaTimeStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy SourceVector;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy DeltaTimeVector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!SourceVector.TryGet(entity, out var first))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
                return false;
            }

            if (!DeltaTimeVector.TryGet(entity, out var second))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
                return false;
            }

            result = first + second * Time.deltaTime;
            return true;
        }
    }
}