namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public interface IEntityConfigStrategy
    {
        bool TryGet(GameEntity entity, out GameEntityConfig config);
    }
}