namespace Ruinum.ECS.Core.Conditions
{
    public class NegateCondition : EntityCondition
    {
        public IEntityCondition Condition;

        protected override bool IsTrue(GameEntity entity)
        {
            return !Condition.IsConditionTrue(entity);
        }
    }
}