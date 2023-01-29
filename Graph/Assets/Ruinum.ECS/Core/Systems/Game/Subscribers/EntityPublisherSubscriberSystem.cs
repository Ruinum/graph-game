using Entitas;

namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public abstract class EntityPublisherSubscriberSystem<TPub, TSub, TValue> : Feature where TPub : EntityPublisherComponent where TSub : EntitySubscriberComponent where TValue : IComponent
    {
        protected EntityPublisherSubscriberSystem(GameContext context, IMatcher<GameEntity> valueMatcher, IMatcher<GameEntity> subscriberMatcher)
        {
            base.Add(new EntityPublisherSystem<TSub, TPub>(context.CreateCollector(valueMatcher.AddedOrRemoved())));
            base.Add(new EntitySubscriberSystem<TSub, TPub, TValue>(context, subscriberMatcher));
        }
    }
}