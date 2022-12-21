using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class TargetMaxFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
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

            value = target.maxFloatValue.Value;
            return true;
        }
    }
}