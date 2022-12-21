namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public abstract class FloatValueBaseStrategy : ContextInitializable, IFloatValueStrategy
    {
        public abstract bool TryGet(GameEntity entity, out float value);
    }
}
