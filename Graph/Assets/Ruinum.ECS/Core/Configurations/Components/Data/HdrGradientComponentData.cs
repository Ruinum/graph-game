using Sirenix.OdinInspector;
using UnityEngine;

public sealed class HdrGradientComponentData : IComponentData
{
    [HideReferenceObjectPicker, GradientUsage(true), HideLabel] public Gradient Value = new Gradient();
}