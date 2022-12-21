using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class AccelerationComponent : IComponent
{
    public float Value;
}