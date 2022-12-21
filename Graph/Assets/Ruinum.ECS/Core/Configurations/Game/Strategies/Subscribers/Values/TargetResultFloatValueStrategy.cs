using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class TargetResultFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (Target.TryGet(entity, out _))
            {
                value = 1;
                return true;
            }
            value = 0;
            return true;
        }
    }
}