namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class CurrentEntityTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            targetEntity = entity;
            return true;
        }
    }
}