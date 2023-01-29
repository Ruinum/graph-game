using Ruinum.ECS.Configurations.Components;

public interface IDataTypeValueData
{
#if UNITY_EDITOR
    public void SetDataType(ComponentDataTypeConfig dataType);
#endif
}