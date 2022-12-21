using Entitas;
using UnityEngine;

[Game]
public sealed class RotationComponent : IComponent
{
    public Quaternion Value;
}