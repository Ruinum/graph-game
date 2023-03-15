using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game][System.Serializable][EditorComponent]
public class ColorComponent : IComponent
{ 
    [EntityIndex] public Color Color;
}
