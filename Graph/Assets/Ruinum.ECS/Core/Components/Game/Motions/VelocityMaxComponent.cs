using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class VelocityMaxComponent : IComponent
{
    public float Value;
}