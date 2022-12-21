using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    public sealed class PublisherTargetEntityStrategy : SubscriberEntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityStrategy Strategy;

        public override bool Process(GameEntity publisher, GameEntity subscriber)
        {
            return Strategy.Process(publisher);
        }
    }
}