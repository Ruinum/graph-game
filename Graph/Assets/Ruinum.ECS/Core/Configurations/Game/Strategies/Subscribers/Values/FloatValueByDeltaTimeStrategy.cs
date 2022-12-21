using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class FloatValueByDeltaTimeStrategy : FloatValueBaseStrategy
    { 
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy TargetStrategy;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!TargetStrategy.TryGet(entity, out var targetValue))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(targetValue), (nameof(entity), entity));
                return false;
            }

            value = targetValue * Time.deltaTime;
            return true;
        }
    }
}