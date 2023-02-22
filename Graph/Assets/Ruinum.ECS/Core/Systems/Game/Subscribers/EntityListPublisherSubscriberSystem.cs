namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class EntityListPublisherSubscriberSystem : EntityPublisherSubscriberSystem<EntityListPublisherComponent, EntityListSubscriberComponent, EntityListComponent>
    {
        public EntityListPublisherSubscriberSystem(GameContext context) : base(context, GameMatcher.EntityList, GameMatcher.EntityListSubscriber)
        {
        }
    }
}