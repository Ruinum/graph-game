using Ruinum.ECS.Configurations.Input;
using Entitas;

[System.Serializable]
[EditorComponent]
[Game]
public sealed class InputDomainGameComponent : IComponent
{
    public InputDomainConfig Config;
}