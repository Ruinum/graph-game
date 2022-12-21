using Entitas;

[EditorComponent][Game]
public sealed class UnloadAssetsByLabelComponent : IComponent
{
    public string[] Labels = new string[0];
}