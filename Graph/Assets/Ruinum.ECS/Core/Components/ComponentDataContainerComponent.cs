using Ruinum.ECS.Components.DataContainers;
using Ruinum.ECS.Configurations.Components;
using Ruinum.ECS.Configurations.Components.Data;
using Ruinum.ECS.Core.Systems.Log;
using Entitas;
using Entitas.CodeGeneration.Attributes;


[System.Serializable]
[Game]
[EditorComponent]
[Event(EventTarget.Self)]
public sealed class ComponentDataContainerComponent : DataTypeValueData<ComponentDataContainerConfig>, IComponentData, IComponent
{
}