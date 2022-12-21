using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ModifierVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Modifier;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Modifier.TryGet(entity, out var value))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity));
                return false;
            }

            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity), (nameof(value), value));
                return false;
            }

            result = vector * value;
            return true;
        }
    }
}