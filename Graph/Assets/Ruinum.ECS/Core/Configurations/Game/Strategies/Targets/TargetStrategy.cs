using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    [ShowOdinSerializedPropertiesInInspector]
    public abstract class TargetStrategy : ContextInitializable, ITargetStrategy
    {
        public abstract bool TryGet(GameEntity entity, out GameEntity targetEntity);
    }
}