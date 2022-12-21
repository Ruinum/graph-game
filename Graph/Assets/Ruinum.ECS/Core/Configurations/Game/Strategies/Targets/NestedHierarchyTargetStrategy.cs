using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class NestedHierarchyTargetStrategy : TargetStrategy
    {
        public GameEntityConfig Config;

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            return entity.TryGetNestedEntityByConfig(Contexts.game, Config, out targetEntity);
        }
    }
}