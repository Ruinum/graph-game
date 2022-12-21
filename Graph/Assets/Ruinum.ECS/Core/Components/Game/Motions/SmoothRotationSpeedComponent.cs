using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class SmoothRotationSpeedComponent : IComponent
{
    public float Value;
}