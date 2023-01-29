using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Components
{
    public class ComponentDataTypeRecord : ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private string _id;

        public string Id => _id;

        [ReadOnly, MultiLineProperty(Lines = 2), HideLabel, GUIColor(nameof(GetColor)), HorizontalGroup("Group", Width = 200), BoxGroup("Group/1", false)]
        public string Name;

        [HideInInspector] public Type ObjectType;

        [HideReferenceObjectPicker, HideLabel, HorizontalGroup("Group"), BoxGroup("Group/2", false)]
        public object Value;

        [HideInInspector] public bool IsUnrelated = false;
        [HideInInspector] public bool IsTypeChanged = false;

        public ComponentDataTypeRecord(ComponentDataType dataType)
        {
            _id = dataType.Id;
            Name = dataType.Name;
            ObjectType = dataType.DataType;
            Value = Activator.CreateInstance(dataType.DataType);
        }

        private Color GetColor()
        {
            return IsUnrelated ? Color.red : IsTypeChanged ? Color.yellow : Color.green;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            if (Value != null)
            {
                ObjectType = Value.GetType();
            }
        }
    }
}