using Ruinum.ECS.Assets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Configurations.Game.Strategies.Prefab
{
    public sealed class PrefabDataContainerStrategy : DataContainerValueStrategy<PrefabComponent>, IPrefabStrategy
    {
        public bool TryGet(GameEntity entity, out ComponentReference<GameEntityBehaviour> resource)
        {
            if (!TryGetComponentData(entity, out var data))
            {
                resource = default;
                if(Logging) LogErrorNotFound(nameof(data), (nameof(entity), entity));
                return false;
            }

            resource = data.Reference;
            return true;
        }
    }
} 