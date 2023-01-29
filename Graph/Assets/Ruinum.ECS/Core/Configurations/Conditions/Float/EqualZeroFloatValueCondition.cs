using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public sealed class EqualZeroFloatValueCondition : FloatValueCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public EqualityType Equality;

        protected override bool IsTrue(GameEntity entity, float value)
        {
            return ConditionUtilities.IsConditionTrue(Equality, 0.0f, value);
        }
    }
}