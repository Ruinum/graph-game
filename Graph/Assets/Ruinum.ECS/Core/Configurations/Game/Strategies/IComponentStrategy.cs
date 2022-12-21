namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public interface IComponentStrategy<T>
    {
        bool TryGet(GameEntity entity, out T result);
    }
}