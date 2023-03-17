namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class ColorPublisherSubscriberSystem : EntityPublisherSubscriberSystem<
        ColorPublisherComponent, ColorSubscriberComponent, ColorComponent>
    {
        public ColorPublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.Color,
            GameMatcher.ColorSubscriber)
        {
        }
    }
}