using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ClampMagnitudeVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Vector = new SimpleVectorStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy MaxLength = new SimpleFloatValueStrategy();
        
        public override bool TryGet(GameEntity entity, out Vector3 value)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
                return false;
            }

            if (!MaxLength.TryGet(entity, out var length))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(length), (nameof(entity), entity));
                return false;
            }

            value = Vector3.ClampMagnitude(vector, length);
            return true;
        }
    }
}