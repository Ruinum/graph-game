using Ruinum.ECS.Assets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Configurations.Game.Strategies.Prefab
{
    public interface IPrefabStrategy
    {
        bool TryGet(GameEntity entity, out ComponentReference<GameEntityBehaviour> resource);
    }
}