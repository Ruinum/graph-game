using Entitas;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Sirenix.OdinInspector;

[ShowOdinSerializedPropertiesInInspector][System.Serializable][EditorComponent][Game]
public sealed class AudioTargetComponent : IComponent
{
    [HideLabel][AssetSelector(Filter = "t:TargetStrategyConfig")] public ITargetStrategy Target;
}