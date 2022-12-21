using Ruinum.ECS.Configurations.Game.Strategies.Subscribers;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace BeastHour.Configurations.Game.Strategies.Subscribers
{
    public sealed class FindSubscriberStrategy : SubscriberEntityStrategy
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
            if (!Strategy.Process(publisher, target))
            {
                if(Logging) LogError("Failed to Strategy.Process(publisher, target).", (nameof(target), target));
                return false;
            }
            return true;
            
            //TODO: Old implementation. Remove.
            //return Target.TryGet(subscriber, out var target) && Strategy.Process(publisher, target);
        }
    }
}