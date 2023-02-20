using Ruinum.ECS.Systems.Game.Subscribers;

public sealed class MaxFloatValuePublisherSubscriberSystem : EntityPublisherSubscriberSystem<MaxFloatValuePublisherComponent, MaxFloatValueSubscriberComponent, MaxFloatValueComponent>
{

    public MaxFloatValuePublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.MaxFloatValue, GameMatcher.MaxFloatValueSubscriber)
    {
    }
}