using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VectorBySingleFloatValueStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Value;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Value.TryGet(entity, out var value))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity));
                return false;
            }

            result = new Vector3(value, value, value);
            return true;
        }
    }
}