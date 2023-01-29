using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class TimeMultiplierComponent : IComponent
{
    public float Value;
}
