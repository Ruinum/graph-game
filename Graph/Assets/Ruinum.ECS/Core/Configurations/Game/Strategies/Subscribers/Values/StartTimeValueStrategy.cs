using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class StartTimeValueStrategy : FloatValueBaseStrategy
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

            if (!target.hasStartTime)
            {
                value = default;
                if(Logging) LogErrorNotFound("Target TimeComponent or StartTimeComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            value = target.startTime.Value;
            return true;
        }
    }
}