namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public interface ITargetStrategy
    {
        bool TryGet(GameEntity entity, out GameEntity targetEntity);
    }
}