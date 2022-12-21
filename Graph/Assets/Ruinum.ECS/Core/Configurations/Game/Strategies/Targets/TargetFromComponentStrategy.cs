namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class TargetFromComponentStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!entity.hasGameTarget)
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound("GameTargetComponent", (nameof(entity), entity));
                return false;
            }

            targetEntity = entity.gameTarget.Value;
            return true;
        }
    }
}