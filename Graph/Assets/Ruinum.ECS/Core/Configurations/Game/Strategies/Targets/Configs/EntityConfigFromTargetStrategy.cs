namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public sealed class EntityConfigFromTargetStrategy : EntityConfigStrategy
    {
        public ITargetStrategy Target;
        
        public override bool TryGet(GameEntity entity, out GameEntityConfig config)
        {
            config = default;
            if (!Target.TryGet(entity, out var targetEntity))
            {
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                return false;
            }
            if (!targetEntity.HasConfigIndexCached)
            {
                if (Logging) LogErrorNotFound("configIndex component", (nameof(targetEntity), targetEntity), (nameof(entity), entity));
                return false;
            }
            config = Services.Config.GetConfig(targetEntity.ConfigIndexCached);
            return true;
        }
    }
}