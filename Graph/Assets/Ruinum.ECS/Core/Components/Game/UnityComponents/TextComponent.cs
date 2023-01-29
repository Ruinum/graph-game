using Entitas;
using Entitas.CodeGeneration.Attributes;

[EditorComponent][Game][Event(EventTarget.Self)][Event(EventTarget.Any)][Event(EventTarget.Any, EventType.Removed)]
public class TextComponent : IComponent
{
    public string Value;
}