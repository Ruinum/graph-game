using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class TimeEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var value))
            {
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceTime(value);
            return true;
        }
    }
}