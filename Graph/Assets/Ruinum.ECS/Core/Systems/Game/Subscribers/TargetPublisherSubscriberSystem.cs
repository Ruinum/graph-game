namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class TargetPublisherSubscriberSystem : EntityPublisherSubscriberSystem<TargetPublisherComponent, TargetSubscriberComponent, GameTargetComponent>
    {
        public TargetPublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.GameTarget, GameMatcher.TargetSubscriber)
        {
        }
    }
}