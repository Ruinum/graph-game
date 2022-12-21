namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public interface IEntityStrategy : IContextInitializable
    {
        public bool Process(GameEntity entity);
    }
}