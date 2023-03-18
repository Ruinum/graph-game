using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LerpVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy FirstVector = new SimpleVectorStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy SecondVector = new SimpleVectorStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy LerpTime = new SimpleFloatValueStrategy();

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!FirstVector.TryGet(entity, out var first))
            {
                if(Logging) LogErrorNotFound(nameof(FirstVector), (nameof(entity), entity));
                result = default;
                return false;
            }

            if (!SecondVector.TryGet(entity, out var second))
            {
                if(Logging) LogErrorNotFound(nameof(SecondVector), (nameof(entity), entity));
                result = default;
                return false;
            }

            if (!LerpTime.TryGet(entity, out var lerpTime))
            {
                if(Logging) LogErrorNotFound(nameof(LerpTime), (nameof(entity), entity));
                result = default;
                return false;
            }

            result = Vector3.Lerp(first, second, lerpTime);
            return true;
        }
    }
}