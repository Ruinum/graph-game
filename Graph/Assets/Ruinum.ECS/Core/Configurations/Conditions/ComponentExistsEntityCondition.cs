using Ruinum.ECS.Configurations.Conditions.General;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities
{
    public sealed class ComponentExistsEntityCondition : EntityCondition
    {
        [HideReferenceObjectPicker, HideLabel, LabelWidth(EditorConstants.SmallLabelWidth)] public ComponentsContainer Components = new ComponentsContainer();

        protected override bool IsTrue(GameEntity entity)
        {
            for (int i = 0, max = Components.ComponentIndexes.Length; i < max; i++)
            {
                if (!entity.HasComponent(Components.ComponentIndexes[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}