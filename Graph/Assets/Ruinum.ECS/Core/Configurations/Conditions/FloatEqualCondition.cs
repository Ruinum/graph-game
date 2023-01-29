using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Core.Conditions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities
{
    public abstract class FloatEqualCondition : EntityCondition
    {
        [PropertyOrder(5000), LabelWidth(EditorConstants.SmallLabelWidth)] public float Value;
        [PropertyOrder(4000), LabelWidth(EditorConstants.SmallLabelWidth)] public EqualityType Equality;

        protected bool IsEqual(float value)
        {
            return ConditionUtilities.IsConditionTrue(Equality, Value, value);
        }
    }
}
