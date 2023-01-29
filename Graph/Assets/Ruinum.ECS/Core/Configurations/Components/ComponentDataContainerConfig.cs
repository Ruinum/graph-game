using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Components
{
    [CreateAssetMenu(menuName = EditorConstants.RootMenuConfigPath + nameof(ComponentDataContainerConfig), fileName = nameof(ComponentDataContainerConfig))]
    [ShowOdinSerializedPropertiesInInspector]
    public sealed class ComponentDataContainerConfig : SerializedScriptableObject, IConfigIndexMember
    {
        public int ConfigIndex { get; private set; } = -1;

        public ComponentDataTypeConfig DataTypeConfig;

        [ValueDropdown(nameof(GetComponentDataTypeDropdown), IsUniqueList = true, DrawDropdownForListElements = false)]
        [OdinSerialize, ShowInInspector, HideReferenceObjectPicker, OnValueChanged(nameof(OnListChanged)), OnInspectorGUI(nameof(OnGui))]
        private List<ComponentDataTypeRecord> _data = new List<ComponentDataTypeRecord>();

        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public void SetIndex(int index)
        {
            ConfigIndex = index;
        }

        public bool TryGetValue<T>(ComponentDataTypeConfigElement<T> dataType, out T result) where T : IComponentData
        {
            if (_dictionary.TryGetValue(dataType.Id, out var data) && TryCast(data, out result))
            {
                return true;
            }
            result = default;
            return false;
        }

        public bool TryGetValue<T>(string dataTypeId, out T result)
        {
            if (_dictionary.TryGetValue(dataTypeId, out var data) && TryCast(data, out result))
            {
                return true;
            }
            result = default;
            return false;
        }

        private static bool TryCast<T>(object data, out T result)
        {
            if (data is T typedData)
            {
                result = typedData;
                return true;
            }
            result = default;
            return false;
        }

        private IEnumerable GetComponentDataTypeDropdown()
        {
            return DataTypeConfig?.GetComponentDataTypes()
                .Where(m => !_dictionary.ContainsKey(m.Id))
                .Select(m => new ValueDropdownItem<ComponentDataTypeRecord>(m.Name, new ComponentDataTypeRecord(m)));
        }

        private void OnGui()
        {
            if (DataTypeConfig == null)
            {
                return;
            }
            for (int i = 0, max = _data.Count; i < max; i++)
            {
                var componentDataTypeRecord = _data[i];
                if (DataTypeConfig.TryGetComponentDataType(componentDataTypeRecord.Id, out var componentDataType))
                {
                    componentDataTypeRecord.Name = componentDataType.Name;
                    componentDataTypeRecord.IsTypeChanged = !(componentDataTypeRecord.ObjectType == componentDataType.DataType);
                }
                else
                {
                    componentDataTypeRecord.IsUnrelated = true;
                }
            }
        }

        private void OnListChanged()
        {
            _dictionary = _data.ToDictionary(m => m.Id, n => n.Value);
        }

        protected override void OnAfterDeserialize()
        {
            OnListChanged();
        }

#if UNITY_EDITOR
        public bool TryGetValue(string id, out object result)
        {
            return _dictionary.TryGetValue(id, out result);
        }
#endif
    }
}