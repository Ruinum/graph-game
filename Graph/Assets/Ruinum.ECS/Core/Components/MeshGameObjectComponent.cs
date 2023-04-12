using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game][Event(EventTarget.Self)]
public class MeshGameObjectComponent : IComponent
{
    public GameObject Value;
}
