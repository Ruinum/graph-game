using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class ConditionResultFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityCondition Condition;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (Condition.IsConditionTrue(entity))
            {
                value = 1;
                return true;
            }
            value = -1;
            return true;
        }
    }
}