using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VelocityValueStrategy : FloatValueBaseStrategy
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

            if (!target.hasVelocity)
            {
                value = default;
                if(Logging) LogErrorNotFound("VelocityComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            value = target.velocity.Value;
            return true;
        }
    }
}