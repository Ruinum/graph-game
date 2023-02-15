using System;

using System.Linq;

using Ruinum.ECS.Entity.Interfaces;

using Entitas;

using Ruinum.ECS.Components;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Core.Utility.Native;
using Ruinum.Entities.Game;

using UnityEngine;

namespace Ruinum.ECS.Configurations
{
    public abstract partial class EntityConfig : InitializableSerializedConfig, IConfigIndexMember
    {
        public int ConfigIndex { get; protected set; } = -1;

        public abstract void SetIndex(int index);

        public abstract Type[] ComponentTypes { get; }

        public abstract string[] ComponentNames { get; }

        public abstract int[] GetComponentIndexes();

        public abstract TComponent GetComponent<TComponent>(int index) where TComponent : IComponent;
    }

    public abstract class EntityConfig<T> : EntityConfig where T : class, IConfigIndexEntity, IEntityComponentCopy
    {
        protected IContext<T> Context;
        [SerializeField] [HideInInspector] private IComponent[] _serializedComponents = new IComponent[0];
        protected IComponent[] Components = new IComponent[0];
        protected int[] ComponentIndexes = new int[0];
        private int _configIndexComponentIndex;

        public override bool HasComponent(int index)
        {
            return Components[index] != null;
        }

        public override TComponent GetComponent<TComponent>(int index)
        {
            return (TComponent)GetComponent(index);
        }

        public override IComponent GetComponent(int index)
        {
            return Components[index];
        }

        public override void SetIndex(int index)
        {
            ConfigIndex = index;
        }

        public T Configure(T entity)
        {
            for (int i = 0, max = ComponentIndexes.Length; i < max; i++)
            {
                var componentIndex = ComponentIndexes[i];
                entity.CopyComponent(componentIndex, Components[componentIndex]);
            }
            return entity;
        }

        public T Create(bool createNested = true)
        {
            var entity = Context.CreateEntity();
            ProcessIndex(entity);
            Configure(entity);
            if (createNested)
            {
                CreateNested(entity);
            }
            return entity;
        }

        public void ProcessIndex(T entity)
        {
            ValidateConfigIndex();
            var configIndexComponent = entity.CreateComponent<ConfigIndexComponent>(_configIndexComponentIndex);
            configIndexComponent.Value = ConfigIndex;
            entity.AddComponent(_configIndexComponentIndex, configIndexComponent);
            entity.SetConfigIndex(ConfigIndex);
        }

        protected void ValidateConfigIndex()
        {
            if (ConfigIndex == -1)
            {
                LogExtention.Error($"Entity config {name} does not initialized by configIndex");
            }
        }

        protected override void OnBeforeSerialize()
        {
            DeserializeComponents();
        }

        protected override void OnAfterDeserialize()
        {
            DeserializeComponents();
        }      

        private void DeserializeComponents()
        {
            _configIndexComponentIndex = ComponentTypes.IndexOf<ConfigIndexComponent>();
            Components = new IComponent[ComponentTypes.Length];
            for (int i = _serializedComponents.Length - 1; i >= 0; i--)
            {
                var component = _serializedComponents[i];
                if (component == null)
                {
                    LogExtention.Error($"{GetType().Name} has unknown member component.");
                    ArrayUtility.RemoveAt(ref _serializedComponents, i);
                    continue;
                }
                var index = ComponentTypes.IndexOf(component.GetType());
                if (index == -1)
                {
                    LogExtention.Error($"{GetType().Name} has unknown member component {component.GetType()}.");
                    ArrayUtility.RemoveAt(ref _serializedComponents, i);
                    continue;
                }
                Components[index] = component;
            }
            ProcessComponentIndexes();
        }

        private void ProcessComponentIndexes()
        {
            ComponentIndexes = new int[_serializedComponents.Length];
            for (int i = 0, max = _serializedComponents.Length; i < max; i++)
            {
                ComponentIndexes[i] = ComponentTypes.IndexOf(_serializedComponents[i].GetType());
            }
        }

        protected virtual void CreateNested(T entity)
        {
        }

        public override int[] GetComponentIndexes() => ComponentIndexes;

        #region Editor 
#if UNITY_EDITOR
        public override Type EntityType { get; } = typeof(T);

        public override IComponent[] GetComponents()
        {
            var components = new IComponent[ComponentIndexes.Length];
            for (int i = 0, max = ComponentIndexes.Length; i < max; i++)
            {
                components[i] = Components[ComponentIndexes[i]];
            }
            return components;
        }

        public override void ReplaceComponent(int index, IComponent replacement)
        {
            if (HasComponent(index))
            {
                RemoveComponent(index);
            }
            AddComponent(index, replacement);
        }

        public override void AddComponent(int index, IComponent component)
        {
            if (HasComponent(index))
            {
                LogExtention.Error("Component already exists in entityConfig " + name);
            }
            ArrayUtility.Add(ref _serializedComponents, component);
            _serializedComponents = _serializedComponents.OrderBy(m => GameComponentsLookup.componentTypes.IndexOf(m.GetType())).ToArray();
            Components[index] = component;
            ProcessComponentIndexes();
        }

        public override void RemoveComponent(int index)
        {
            if (!HasComponent(index))
            {
                return;
            }
            ArrayUtility.Remove(ref _serializedComponents, Components[index]);
            Components[index] = null;
            ProcessComponentIndexes();
        }
#endif
        #endregion
    }
}