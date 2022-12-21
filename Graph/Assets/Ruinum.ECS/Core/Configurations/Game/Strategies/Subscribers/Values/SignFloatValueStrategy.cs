using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class SignFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy Value;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Value.TryGet(entity, out var floatValue))
            {
                if(Logging) LogErrorNotFound(nameof(floatValue), (nameof(entity), entity));
                value = default;
                return false;
            }
            
            value = Mathf.Sign(floatValue);
            return true;
        }
    }
}