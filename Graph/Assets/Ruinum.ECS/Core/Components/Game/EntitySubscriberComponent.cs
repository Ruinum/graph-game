using Ruinum.ECS.Configurations.Game.Strategies.Subscribers;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Entitas;
using Sirenix.OdinInspector;

[ShowOdinSerializedPropertiesInInspector]
public abstract class EntitySubscriberComponent : IComponent
{
    [AssetSelector(Filter = "t:SubscriberEntityStrategyConfig")] [LabelWidth(EditorConstants.SmallLabelWidth)] public ISubscriberEntityStrategy Strategy = new SubscriberTargetEntityStrategy();
    [AssetSelector(Filter = "t:TargetStrategyConfig")] [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
}