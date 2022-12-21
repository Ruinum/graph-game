using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class MaxFloatValueMinusFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Target.TryGet(entity, out var target))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasMaxFloatValue)
            {
                value = default;
                if(Logging) LogErrorNotFound("MaxFloatValueComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!target.hasFloatValue)
            {
                value = default;
                if(Logging) LogErrorNotFound("FloatValueComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            value = target.maxFloatValue.Value - target.floatValue.Value;
            return true;
        }
    }
}