using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[System.Serializable]
[EditorComponent]
[Event(EventTarget.Self)]
public class ColorComponent : IComponent
{ 
    [EntityIndex] public Color Color;
}
