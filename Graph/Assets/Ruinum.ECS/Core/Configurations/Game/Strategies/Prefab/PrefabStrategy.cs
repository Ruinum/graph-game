using Ruinum.ECS.Assets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Configurations.Game.Strategies.Prefab
{
    public abstract class PrefabStrategy : ContextInitializable, IPrefabStrategy
    {
        public abstract bool TryGet(GameEntity entity, out ComponentReference<GameEntityBehaviour> resource);
    }
}