using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System;
using System.Linq;

namespace Ruinum.ECS.Configurations.Components
{
    public class ComponentDataType
    {
        [HideInInspector] public readonly string Id;
        [HideLabel] public string Name;
        [ValueDropdown(nameof(GetTypes)), HideLabel, HorizontalGroup("Type")] public Type DataType;

        protected virtual bool IsDataTypeEditable() => true;

        public ComponentDataType()
        {
            Id = Guid.NewGuid().ToString();
        }

        public ComponentDataType(string id)
        {
            Id = id;
        }

        protected virtual IEnumerable<Type> GetTypes()
        {
            return typeof(IComponentData).Assembly.GetTypes().Where(m =>
                !m.IsAbstract && !m.IsGenericTypeDefinition && typeof(IComponentData).IsAssignableFrom(m) && !typeof(IDataTypeValueData).IsAssignableFrom(m));
        }

        public override bool Equals(object obj)
        {
            if (obj is ComponentDataType dataType)
            {
                return Id.Equals(dataType.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}