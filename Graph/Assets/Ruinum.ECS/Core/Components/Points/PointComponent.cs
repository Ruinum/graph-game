using Entitas.CodeGeneration.Attributes;

[System.Serializable]
[EditorComponent]
[Game]
[Event(EventTarget.Self)]
public sealed class PointComponent : Vector3ValueComponent
{
}