namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public abstract class ComponentStrategy<T> : ContextInitializable, IComponentStrategy<T>
    {
        public abstract bool TryGet(GameEntity entity, out T result);
    }
}