namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class OwnerTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!entity.HasOwner)
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound("GameOwnerComponent", (nameof(entity), entity));
                return false;
            }

            targetEntity = entity.OwnerEntity;
            return true;
        }
    }
}