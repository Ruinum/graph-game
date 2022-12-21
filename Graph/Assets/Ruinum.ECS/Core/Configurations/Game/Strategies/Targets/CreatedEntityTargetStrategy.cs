namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class CreatedEntityTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!entity.hasGameCreatedEntity)
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound("GameCreatedEntityComponent", (nameof(entity), entity));
                return false;
            }
            targetEntity = entity.gameCreatedEntity.Value;
            return true;
        }
    }
}