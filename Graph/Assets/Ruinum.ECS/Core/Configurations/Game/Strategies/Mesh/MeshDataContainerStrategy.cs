using Ruinum.ECS.Configurations.Components.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Ruinum.ECS.Configurations.Game.Strategies.Mesh
{
    public sealed class MeshDataContainerStrategy : DataContainerValueStrategy<MeshComponent>, IMeshStrategy
    {
        public bool TryGet(GameEntity entity, out AssetReferenceGameObject mesh)
        {
            if (!TryGetComponentData(entity, out var data))
            {
                mesh = default;
                if(Logging) LogErrorNotFound(nameof(data), (nameof(entity), entity));
                return false;
            }

            mesh = data.Reference;
            return true;
        }
    }
}