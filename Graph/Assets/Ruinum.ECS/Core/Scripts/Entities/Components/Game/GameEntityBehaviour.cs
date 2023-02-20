using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Core.Systems.Log;
using System.Collections.Generic;
using UnityEngine;


namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [DisallowMultipleComponent]
    public sealed class GameEntityBehaviour : MonoBehaviour, IDestroyedListener
    {
        public GameEntity Entity { get; private set; }
        private readonly List<GameEntityComponentBehaviour> _behaviours = new List<GameEntityComponentBehaviour>();

        public void SetEntity(GameEntity entity)
        {
            if (Entity != null)
            {
                LogExtention.Error($"{nameof(GameEntityBehaviour)} already initialized by Entity {Entity}. GameObject: {gameObject.name}.New entity {entity}");
                return;
            }
            Entity = entity;
            Entity.Retain(this);
            AddDestroyedListener();
            foreach (var component in GetComponents<GameEntityComponentBehaviour>())
            {
                _behaviours.Add(component);
                component.SetEntity(Entity);
            }
        }

        private void AddDestroyedListener()
        {
            Entity.AddDestroyedListener(this);
        }

        private void RemoveDestroyedListener()
        {
            Entity.RemoveDestroyedListener(this);
        }

        private void OnDestroy()
        {
            if (Entity == null || !Entity.isEnabled)
            {
                return;
            }
            Entity.isDestroyed = true;
            ReleaseEntity();
        }

        public void OnDestroyed(GameEntity entity)
        {
            if (!this.IsNull())
            {
                Destroy(gameObject);
            }
            if (Entity == null || !Entity.isEnabled)
            {
                return;
            }
            ReleaseEntity();
        }

        private void ReleaseEntity()
        {
            RemoveDestroyedListener();
            Entity.Release(this);
            foreach (var component in _behaviours)
            {
                component.OnEntityDestroy();
            }
            Entity = null;
        }
    }
}