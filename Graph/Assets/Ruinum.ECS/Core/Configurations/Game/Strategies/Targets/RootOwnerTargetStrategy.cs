using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class RootOwnerTargetStrategy : TargetStrategy
    {
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            targetEntity = entity.GetRootOwnerOrThis();
            return true;
        }
    }
}