namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    public interface ISubscriberEntityStrategy : IContextInitializable
    {
        bool Process(GameEntity publisher, GameEntity subscriber);
    }
}