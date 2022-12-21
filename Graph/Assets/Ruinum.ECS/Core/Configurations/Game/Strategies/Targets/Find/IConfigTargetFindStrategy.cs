namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Find
{
    public interface IConfigTargetFindStrategy
    {
        bool TryGet(GameEntity entity, GameEntityConfig config, out GameEntity target);
    }
}