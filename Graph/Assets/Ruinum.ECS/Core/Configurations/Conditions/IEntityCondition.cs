namespace Ruinum.ECS.Core.Conditions
{
    public interface IEntityCondition
    {
        public bool IsConditionTrue(GameEntity entity);
    }
}