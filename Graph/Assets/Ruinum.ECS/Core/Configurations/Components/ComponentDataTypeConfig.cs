using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Components
{
    [ShowOdinSerializedPropertiesInInspector]
    [CreateAssetMenu(menuName = EditorConstants.RootMenuConfigPath + nameof(ComponentDataTypeConfig), fileName = nameof(ComponentDataTypeConfig))]
    public sealed class ComponentDataTypeConfig : SerializedScriptableObject
    {
        [HideReferenceObjectPicker, SerializeField, TableList(AlwaysExpanded = true, HideToolbar = true)]
        private readonly List<ComponentDataType> _dataType = new List<ComponentDataType>();

        private Dictionary<string, ComponentDataType> _dataDictionary = new Dictionary<string, ComponentDataType>();

        public bool TryGetComponentDataType(string id, out ComponentDataType componentDataType)
        {
            return _dataDictionary.TryGetValue(id, out componentDataType);
        }

        public List<ComponentDataType> GetComponentDataTypes()
        {
            return _dataType;
        }

        private void OnValueChange()
        {
            _dataDictionary = _dataType.ToDictionary(m => m.Id, n => n);
        }

        protected override void OnAfterDeserialize()
        {
            OnValueChange();
        }

        [Button]
        private void AddDataType()
        {
            _dataType.Add(new ComponentDataType());
        }

        [Button(ButtonSizes.Small)]
        private void Save()
        {
            OnValueChange();
        }
    }
}
