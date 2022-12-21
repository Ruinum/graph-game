using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class RoundToIntFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.LargeLabelWidth)] public IFloatValueStrategy Value;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Value.TryGet(entity, out var targetValue))
            {
                if(Logging) LogErrorNotFound(nameof(targetValue), (nameof(entity), entity));
                value = default;
                return false;
            }
        
            value = Mathf.Round(targetValue);
            return true;
        }
    }
}