namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public abstract class EntityConfigStrategy : ContextInitializable, IEntityConfigStrategy
    {
        public abstract bool TryGet(GameEntity entity, out GameEntityConfig config);
    }
}