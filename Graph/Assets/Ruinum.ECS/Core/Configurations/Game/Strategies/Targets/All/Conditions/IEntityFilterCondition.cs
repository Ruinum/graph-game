namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    public interface IEntityFilterCondition
    {
        bool IsConditionTrue(GameEntity entity, GameEntity target);
    }
}