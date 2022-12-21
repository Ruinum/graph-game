using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(GameEntityBehaviour))]
    public abstract class GameEntityComponentBehaviour : SerializedMonoBehaviour
    {
        protected GameEntity Entity { get; private set; }
        protected bool Initialized;
        
        public void SetEntity(GameEntity entity)
        {
            Entity = entity;
            Entity.Retain(this);
            Initialized = true;
            OnSetEntity(entity);
        }

        protected virtual void OnSetEntity(GameEntity entity)
        {
        }

        public void OnEntityDestroy()
        {
            Entity.Release(this);
            Initialized = false;
            OnEntityDestroyed();
        }

        protected virtual void OnEntityDestroyed()
        {
        }
    }
}