using UnityEngine.AddressableAssets;

namespace Ruinum.ECS.Configurations.Game.Strategies.Mesh
{
    public interface IMeshStrategy
    {
        bool TryGet(GameEntity entity, out AssetReferenceGameObject mesh);
    }
}
