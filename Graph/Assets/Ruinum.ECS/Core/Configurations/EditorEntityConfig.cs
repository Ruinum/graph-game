using System;
using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Configurations
{
#if UNITY_EDITOR
    public partial class EntityConfig : IEntity
    {
        public abstract Type EntityType { get; }

        public abstract void RemoveComponent(int index);

        public abstract void AddComponent(int index, IComponent component);

        public abstract IComponent[] GetComponents();

        public abstract void ReplaceComponent(int index, IComponent replacement);

        #region IEntity methods

        public int[] GetComponentIndices() => GetComponentIndexes();

        public virtual bool HasComponents(int[] indices)
        {
            throw new NotImplementedException();
        }

        public virtual bool HasAnyComponent(int[] indices)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveAllComponents()
        {
            throw new NotImplementedException();
        }

        public virtual Stack<IComponent> GetComponentPool(int index)
        {
            throw new NotImplementedException();
        }

        public virtual IComponent CreateComponent(int index, Type type)
        {
            throw new NotImplementedException();
        }

        public virtual T CreateComponent<T>(int index) where T : new()
        {
            throw new NotImplementedException();
        }

        public virtual void Destroy()
        {
            throw new NotImplementedException();
        }

        public virtual void InternalDestroy()
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveAllOnEntityReleasedHandlers()
        {
            throw new NotImplementedException();
        }

        public int totalComponents => throw new NotImplementedException();

        public int creationIndex => throw new NotImplementedException();

        public bool isEnabled => throw new NotImplementedException();

        public Stack<IComponent>[] componentPools => throw new NotImplementedException();

        public ContextInfo contextInfo => throw new NotImplementedException();

        public IAERC aerc => throw new NotImplementedException();

        public event EntityComponentChanged OnComponentAdded;

        public event EntityComponentChanged OnComponentRemoved;

        public event EntityComponentReplaced OnComponentReplaced;

        public event EntityEvent OnEntityReleased;

        public event EntityEvent OnDestroyEntity;

        public virtual void Initialize(int creationIndex, int totalComponents, Stack<IComponent>[] componentPools, ContextInfo contextInfo = null, IAERC aerc = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Reactivate(int creationIndex)
        {
            throw new NotImplementedException();
        }
        public virtual void Retain(object owner)
        {
            throw new NotImplementedException();
        }

        public virtual void Release(object owner)
        {
            throw new NotImplementedException();
        }

        public virtual IComponent GetComponent(int index)
        {
            throw new NotImplementedException();
        }

        public virtual bool HasComponent(int index)
        {
            throw new NotImplementedException();
        }

        public int retainCount => throw new NotImplementedException();
        #endregion
    }
#endif
}
