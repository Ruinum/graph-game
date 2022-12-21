using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Find
{
    [ShowOdinSerializedPropertiesInInspector]
    public abstract class ConfigTargetFindStrategy : ContextInitializable, IConfigTargetFindStrategy
    {
        public abstract bool TryGet(GameEntity entity, GameEntityConfig config, out GameEntity target);
    }
}