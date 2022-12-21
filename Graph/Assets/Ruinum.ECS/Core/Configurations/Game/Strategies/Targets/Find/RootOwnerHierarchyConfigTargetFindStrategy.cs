namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Find
{
    public sealed class RootOwnerHierarchyConfigTargetFindStrategy : ConfigTargetFindStrategy
    {
        public override bool TryGet(GameEntity entity, GameEntityConfig config, out GameEntity target)
        {
            if (entity.HasConfigIndexCached && entity.ConfigIndexCached == config.ConfigIndex)
            {
                target = entity;
                return true;
            }

            if (!TryGetEntityByOwner(entity, config, out target))
            {
                target = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity), (nameof(config), config));
                return false;
            }

            return true;
        }
    }
}