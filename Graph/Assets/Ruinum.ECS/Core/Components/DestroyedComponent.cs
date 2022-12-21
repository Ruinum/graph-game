using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Serializable, EditorComponent, Game, Event(EventTarget.Self, priority: 100)]
public sealed class DestroyedComponent : IComponent
{
}