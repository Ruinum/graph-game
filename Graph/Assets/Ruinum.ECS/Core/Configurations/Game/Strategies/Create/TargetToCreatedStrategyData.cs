using Ruinum.ECS.Configurations.Game.Strategies.Subscribers;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    [ShowOdinSerializedPropertiesInInspector]
    public sealed class TargetToCreatedStrategyData
    {
        [LabelWidth(100)] public ITargetStrategy TargetStrategy = new CurrentEntityTargetStrategy();
        [LabelWidth(100)] public ITargetStrategy CreatedTargetStrategy = new CurrentEntityTargetStrategy();
        [LabelWidth(100)] public ISubscriberEntityStrategy ProcessStrategy = new PublisherToSubscriberCopyStrategy();
    }
}