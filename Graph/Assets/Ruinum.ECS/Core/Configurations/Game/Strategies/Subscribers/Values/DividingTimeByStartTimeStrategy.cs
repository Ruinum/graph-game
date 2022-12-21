using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class DividingTimeByStartTimeStrategy : FloatValueBaseStrategy
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

            if (!target.hasTime)
            {
                value = default;
                if(Logging) LogErrorNotFound("TimeComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!target.hasStartTime)
            {
                value = default;
                if(Logging) LogErrorNotFound("TimeStartComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            value = target.time.Value / target.startTime.Value;
            return true;
        }
    }
}