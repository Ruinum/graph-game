using Sirenix.OdinInspector;
using UnityEngine;

public sealed class Vector3ComponentData : IComponentData
{
    [HideLabel] public Vector3 Value;
}