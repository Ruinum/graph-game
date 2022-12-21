using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    public sealed class FindPublisherStrategy : SubscriberEntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public SubscriberEntityStrategy Strategy;

        public override bool Process(GameEntity publisher, GameEntity subscriber)
        {
            if (!Target.TryGet(subscriber, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(subscriber), subscriber));
                return false;
            }
            if (!Strategy.Process(target, subscriber))
            {
                if(Logging) LogError("Failed to Strategy.Process(target, subscriber).", (nameof(target), target));
                return false;
            }
            return true;           
        }
    }
}