using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    [ShowOdinSerializedPropertiesInInspector]
    public abstract class SubscriberEntityStrategy : ContextInitializable, ISubscriberEntityStrategy
    {
        public abstract bool Process(GameEntity publisher, GameEntity subscriber);
    }
}