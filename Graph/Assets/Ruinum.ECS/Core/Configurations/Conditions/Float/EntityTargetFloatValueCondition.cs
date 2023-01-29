using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public sealed class EntityTargetFloatValueCondition : FloatValueCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityCondition Condition;

        protected override bool IsTrue(GameEntity entity, float value)
        {
            return Condition.IsConditionTrue(entity);
        }
    }
}