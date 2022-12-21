using Entitas;
using UnityEngine;

[Game]
public sealed class TransformRotationComponent : IComponent
{
    public Quaternion Value;
}