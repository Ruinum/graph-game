using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class VelocityModifierComponent : IComponent
{
    public float Value;
}