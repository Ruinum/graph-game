namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class EmptyTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            entity.RemoveGameTarget();
            targetEntity = null;
            
            return true;
        }
    }
}