using Entitas;
using UnityEngine;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class VelocityVectorComponent : IComponent
{
    public Vector3 Value;
}