namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class MainCreatorTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            targetEntity = null;
            return true; // entity.TryGetMainCreator(out targetEntity);
        }
    }
}