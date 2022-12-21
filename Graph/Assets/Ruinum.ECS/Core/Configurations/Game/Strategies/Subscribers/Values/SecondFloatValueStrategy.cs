using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class SecondFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.LargeLabelWidth)] public ITargetStrategy TargetStrategy = new CurrentEntityTargetStrategy();

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                value = default;
                return false;
            }

            if (!target.hasSecondFloatValue)
            {
                if(Logging) LogErrorNotFound(nameof(SecondFloatValueComponent), (nameof(entity), entity), (nameof(target), target));
                value = default;
                return false;
            }

            value = target.secondFloatValue.Value;
            return true;
        }
    }
}