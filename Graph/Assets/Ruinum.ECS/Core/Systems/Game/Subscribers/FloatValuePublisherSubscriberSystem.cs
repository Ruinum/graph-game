namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class FloatValuePublisherSubscriberSystem : EntityPublisherSubscriberSystem<
        FloatValuePublisherComponent, FloatValueSubscriberComponent, FloatValueComponent>
    {
        public FloatValuePublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.FloatValue,
            GameMatcher.FloatValueSubscriber)
        {
        }
    }
}