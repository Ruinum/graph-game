using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class VelocityMinComponent : IComponent
{
    public float Value;
}