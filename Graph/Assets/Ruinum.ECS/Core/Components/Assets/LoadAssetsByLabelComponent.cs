using Entitas;

[EditorComponent][Game]
public sealed class LoadAssetsByLabelComponent : IComponent
{
    public string[] Labels = new string[0];
}