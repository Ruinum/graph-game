using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class ModifyCurrentFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy CurrentValueStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IModifierStrategy Modifier;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!CurrentValueStrategy.TryGet(entity, out var currentValue))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(currentValue), (nameof(entity), entity));
                return false;
            }
            if (!Modifier.TryGet(entity, currentValue, out value))
            {
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity), (nameof(currentValue), currentValue));
                return false;
            }

            return true;                  
        }
    }
}