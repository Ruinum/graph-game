using Ruinum.ECS.Configurations.Components;

namespace Ruinum.ECS.Components.DataContainers
{
    public interface IDataTypeValueData
    {
#if UNITY_EDITOR
        public void SetDataType(ComponentDataTypeConfig dataType);
#endif
    }
}