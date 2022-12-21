using Entitas;
using Ruinum.ECS.Entity.Interfaces;
using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Utilities
{
    public static class EntityUtilities
    {
        public static GameEntity GetRootOwner(GameEntity entity)
        {
            while (true)
            {
                if (!entity.HasOwner)
                {
                    return entity;
                }
                entity = entity.OwnerEntity;
            }
        }

        public static bool TryGetOwnerByConfigIndex(GameEntity entity, int index, out GameEntity owner)
        {
            while (true)
            {
                if (!entity.HasOwner)
                {
                    owner = default;
                    return false;
                }
                owner = entity.OwnerEntity;
                if (owner.HasConfigIndexCached && owner.ConfigIndexCached == index)
                {
                    return true;
                }
                entity = owner;
            }
        }

        public static bool TryGetComponentInOwnerHierarchy<TComponent>(GameEntity entity, int componentIndex, out TComponent component) where TComponent : IComponent
        {
            if (entity.HasComponent(componentIndex))
            {
                component = entity.GetComponent<TComponent>(componentIndex);
                return true;
            }
            while (true)
            {
                if (!entity.HasOwner)
                {
                    component = default;
                    return false;
                }
                var owner = entity.OwnerEntity;
                if (owner.HasComponent(componentIndex))
                {
                    component = owner.GetComponent<TComponent>(componentIndex);
                    return true;
                }
                entity = owner;
            }
        }

        public static void ProcessMainCreator(GameEntity entity, GameEntity created)
        {
            //if (creator.TryGetMainCreator(out var mainCreator))
            //{
            //    created.AddTargetMainCreator(mainCreator);
            //}
        }

        public static bool HasComponentInOwnerHierarchy(GameEntity entity, int componentIndex)
        {
            while (true)
            {
                if (!entity.HasOwner)
                {
                    return false;
                }
                var owner = entity.OwnerEntity;
                if (owner.HasComponent(componentIndex))
                {
                    return true;
                }
                entity = owner;
            }
        }

        public static bool TryGetRootOwner(GameEntity entity, out GameEntity rootOwner)
        {
            if (entity.HasRootOwner)
            {
                rootOwner = entity.RootOwnerEntity;
                return true;
            }
            rootOwner = default;
            return false;
        }

        public static GameEntity GetRootOwnerOrThis(GameEntity entity)
        {
            return entity.HasRootOwner ? entity.RootOwnerEntity : entity;
        }

        public static void CopyComponents<T>(T toEntity, T fromEntity, int[] componentIndexes) where T : class, IEntity, IEntityComponentCopy
        {
            for (int i = 0, max = componentIndexes.Length; i < max; i++)
            {
                var componentIndex = componentIndexes[i];
                if (fromEntity.HasComponent(componentIndex))
                {
                    toEntity.CopyComponent(componentIndex, fromEntity.GetComponent(componentIndex));
                }
            }
        }
    }
}