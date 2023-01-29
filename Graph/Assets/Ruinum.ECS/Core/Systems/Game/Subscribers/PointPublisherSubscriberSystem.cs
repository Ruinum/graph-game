namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class PointPublisherSubscriberSystem : EntityPublisherSubscriberSystem<PointPublisherComponent, PointSubscriberComponent, PointComponent>
    {
        public PointPublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.Point, GameMatcher.PointSubscriber)
        {
        }
    }
}