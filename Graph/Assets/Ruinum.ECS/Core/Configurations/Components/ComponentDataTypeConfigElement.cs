using Sirenix.OdinInspector;
using System.Collections;
using System.Linq;

namespace Ruinum.ECS.Configurations.Components
{
    public class ComponentDataTypeConfigElement<T> where T : IComponentData
    {
        [OnValueChanged(nameof(OnConfigChanged))] public ComponentDataTypeConfig DataTypeConfig;
        [ValueDropdown(nameof(GetDataTypeDropdown)), ShowIf(nameof(IsConfigPicked))] public string Id;

        private IEnumerable GetDataTypeDropdown()
        {
            return DataTypeConfig?.GetComponentDataTypes()
                .Where(m => m.DataType == typeof(T) || typeof(T) == typeof(IComponentData))
                .Select(m => new ValueDropdownItem(m.Name, m.Id));
        }

        private bool IsConfigPicked()
        {
            return DataTypeConfig != null;
        }

        private void OnConfigChanged()
        {
            Id = string.Empty;
        }
    }
}