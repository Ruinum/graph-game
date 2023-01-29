using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public abstract class FloatValueContainerCondition : FloatValueCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueCondition[] Conditions = new IFloatValueCondition[0];
    }
}