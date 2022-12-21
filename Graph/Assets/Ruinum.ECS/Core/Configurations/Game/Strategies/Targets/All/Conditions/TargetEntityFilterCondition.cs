using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    public sealed class TargetEntityFilterCondition : EntityFilterCondition
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IEntityCondition Condition;

        protected override bool IsTrue(GameEntity entity, GameEntity target)
        {
            return Condition.IsConditionTrue(target);
        }
    }
}