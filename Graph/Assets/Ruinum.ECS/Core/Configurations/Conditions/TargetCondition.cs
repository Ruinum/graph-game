using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Conditions
{
    public class TargetCondition : EntityCondition
    {
        public ITargetStrategy TargetStrategy;
        public IEntityCondition Condition;
        protected override bool IsTrue(GameEntity entity)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                return false;
            }
            return Condition.IsConditionTrue(target);
        }
    }
}