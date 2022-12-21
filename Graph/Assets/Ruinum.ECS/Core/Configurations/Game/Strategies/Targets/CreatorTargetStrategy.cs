namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class CreatorTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            //if (!entity.hasCreatorEntity)
            //{
            //    targetEntity = default;
            //    if(Logging) LogErrorNotFound("CreatorEntityComponent", (nameof(entity), entity));
            //    return false;
            //}

            targetEntity = default; //entity.creatorEntity.Value;
            return true;
        }
    }
}