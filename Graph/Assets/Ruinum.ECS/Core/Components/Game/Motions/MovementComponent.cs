using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[System.Serializable]
[EditorComponent]
[Game]
[Event(EventTarget.Self)]
public sealed class MovementComponent : IComponent
{
    public Vector3 Value;
}