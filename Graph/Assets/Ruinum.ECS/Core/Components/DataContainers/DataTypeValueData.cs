using System.Collections;
using Ruinum.ECS.Configurations.Components;
using Ruinum.ECS.Services;
using Ruinum.ECS.Core.Extensions.Unity;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;

namespace Ruinum.ECS.Components.DataContainers
{
    public abstract class DataTypeValueData<T> : ValueData<T>, IDataTypeValueData
    {
        [SerializeField, HideInInspector] private ComponentDataTypeConfig _dataType;
        
#if UNITY_EDITOR
        public ComponentDataTypeConfig DataTypeEditor => _dataType;
        
        public IEnumerable GetConfigs()
        {
            var configs = ConfigService.LoadComponentDataContainerConfigIndexEditor().GetConfigs();
            return _dataType.IsNull()
                ? configs.Select(x => new ValueDropdownItem(x.name, x))
                : configs.Where(m => m.DataTypeConfig == _dataType).Select(x => new ValueDropdownItem(x.name, x));
        }
        
        public void SetDataType(ComponentDataTypeConfig dataType)
        {
            _dataType = dataType;
        }
#endif
    }
}