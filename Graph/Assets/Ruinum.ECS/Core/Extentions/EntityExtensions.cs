using Entitas;

using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Entity.Interfaces;
using Ruinum.ECS.Utilities;

using UnityEngine;

namespace Ruinum.ECS.Extensions
{
    public static class EntityExtensions
    {      
        public static T GetComponent<T>(this IEntity entity, int componentIndex) where T : IComponent
        {
            return (T) entity.GetComponent(componentIndex);
        }

        public static GameEntity GetRootOwner(this GameEntity entity)
        {
            return EntityUtilities.GetRootOwner(entity);
        }

        public static bool TryGetOwnerByConfigIndex(this GameEntity entity, int index, out GameEntity owner) 
        {
            return EntityUtilities.TryGetOwnerByConfigIndex(entity, index, out owner);
        }

        public static bool TryGetComponentInOwnerHierarchy<TComponent>(this GameEntity entity, int componentIndex, out TComponent component) where TComponent : IComponent
        {
            return EntityUtilities.TryGetComponentInOwnerHierarchy(entity, componentIndex, out component);
        }
        
        public static bool TryGetOwnerByComponentInOwnerHierarchy<TComponent>(this GameEntity entity, int componentIndex, out GameEntity resultEntity) where TComponent : IComponent
        {
            if (entity.HasComponent(componentIndex))
            {
                resultEntity = entity;
                return true;
            }
            while (true)
            {
                if (!entity.HasOwner)
                {
                    resultEntity = default;
                    return false;
                }
                var owner = entity.OwnerEntity;
                if (owner.HasComponent(componentIndex))
                {
                    resultEntity = owner;
                    return true;
                }
                entity = owner;
            }
        }
        
        public static bool TryGetComponentInOwnerHierarchy<TComponent>(this GameEntity entity, int componentIndex, out GameEntity resultEntity, out TComponent component) where TComponent : IComponent
        {
            if (TryGetOwnerByComponentInOwnerHierarchy<TComponent>(entity, componentIndex, out resultEntity))
            {
                component = resultEntity.GetComponent<TComponent>(componentIndex);
                return true;
            }
            resultEntity = default;
            component = default;
            return false;
        }

        public static bool HasComponentInOwnerHierarchy(this GameEntity entity, int componentIndex)
        {
            return EntityUtilities.HasComponentInOwnerHierarchy(entity, componentIndex);
        }

        public static bool TryGetNestedEntityByConfig(this GameEntity entity, GameContext context, GameEntityConfig config, out GameEntity target)
        {
            if (entity.HasConfigIndexCached && entity.ConfigIndexCached == config.ConfigIndex)
            {
                target = entity;
                return true;
            }
            foreach (var nestedEntity in context.GetEntitiesWithOwner(entity))
            {
                if (TryGetNestedEntityByConfig(nestedEntity, context, config, out target))
                {
                    return true;
                }
            }
            target = default;
            return false;
        }

        public static bool TryGetRootOwner(this GameEntity entity, out GameEntity rootOwner)
        {
            return EntityUtilities.TryGetRootOwner(entity, out rootOwner);
        }

        public static GameEntity GetRootOwnerOrThis(this GameEntity entity)
        {
            return EntityUtilities.GetRootOwnerOrThis(entity);
        }      

        public static void CopyComponents<T>(this T toEntity, T fromEntity, int[] componentIndexes) where T : class, IEntity, IEntityComponentCopy
        {
            EntityUtilities.CopyComponents(toEntity, fromEntity, componentIndexes);
        }

        public static bool TryGetStartTime(this GameEntity entity, out float time)
        {
            if (entity.hasStartTime)
            {
                time = entity.startTime.Value;
                return true;
            }
            if (entity.hasTime)
            {
                time = entity.time.Value;
                return true;
            }
            time = default;
            return false;
        }

        public static bool TryGetTransform(this GameEntity entity, out Transform transform)
        {
            if (!entity.hasGameObject)
            {
                transform = default;
                return false;
            }
            var gameObject = entity.gameObject.Value;
            if (gameObject.IsNull())
            {
                transform = default;
                return false;
            }
            transform = gameObject.transform;
            return !transform.IsNull();
        }

        public static bool TryGetGameObject(this GameEntity entity, out GameObject gameObject)
        {
            if (entity.hasGameObject)
            {
                gameObject = entity.gameObject.Value;
                return !gameObject.IsNull();
            }
            LogExtention.Error($"{Time.frameCount} Entity {entity} does not have gameObject");
            gameObject = default;
            return false;
        }

        public static bool TryGetGameObjectComponent<T>(this GameEntity entity, out T component) where T : Component
        {
            if (!entity.hasGameObject)
            {
                LogExtention.Error($"{Time.frameCount} Entity {entity} does not have gameObject");
                component = default;
                return false;
            }
            var gameObject = entity.gameObject.Value;
            if (gameObject.IsNull())
            {
                component = default;
                return false;
            }
            component = gameObject.GetComponent<T>();
            if (!component.IsNull())
            {
                return true;
            }
            LogExtention.Error($"Entity {entity} with gameObject {gameObject} does not have component {typeof(T).Name}");
            return false;
        }

        public static bool TryGetCharacterController(this GameEntity entity, out CharacterController characterController)
        {
            if (entity.hasCharacterController)
            {
                characterController = entity.characterController.Value;
                return !characterController.IsNull();
            }
            characterController = default;
            return false;
        }

        public static bool TryGetPositionRotation(this GameEntity entity, out Vector3 position, out Quaternion rotation)
        {
            if (TryGetRotation(entity, out rotation) && TryGetPosition(entity, out position))
            {
                return true;
            }
            position = default;
            rotation = default;
            return false;
        }

        public static bool TryGetRootPositionRotation(this GameEntity entity, out Vector3 position, out Quaternion rotation)
        {
            var rootOwner = entity.GetRootOwnerOrThis();
            if (TryGetRotation(rootOwner, out rotation) && TryGetPosition(rootOwner, out position))
            {
                return true;
            }
            position = default;
            rotation = default;
            return false;
        }

        public static bool TryGetPosition(this GameEntity entity, out Vector3 position)
        {
            if (entity.hasTransformPosition)
            {
                position = entity.transformPosition.Value;
                return true;
            }
            if (entity.hasTransformPositionTo)
            {
                position = entity.transformPositionTo.Position;
                return true;
            }
            position = default;
            return false;
        }

        public static bool TryGetRotation(this GameEntity entity, out Quaternion rotation)
        {
            if (entity.hasTransformRotation)
            {
                rotation = entity.transformRotation.Value;
                return true;
            }
            if (entity.hasTransformRotationTo)
            {
                rotation = entity.transformRotationTo.Value;
                return true;
            }
            rotation = default;
            return false;
        }
    }
}