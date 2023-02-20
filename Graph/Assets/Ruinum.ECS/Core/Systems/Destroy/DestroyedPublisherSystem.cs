using Ruinum.ECS.Systems.Game.Subscribers;
using Entitas;

namespace Ruinum.ECS.Systems.Destroy
{
    public sealed class DestroyedPublisherSystem : EntityPublisherSystem<DestroyedSubscriberComponent, DestroyedPublisherComponent>
    {
        public DestroyedPublisherSystem(IContext<GameEntity> context) : base(
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.DestroyedPublisher, GameMatcher.Destroyed)))
        {
        }

        protected override bool OnFilter(GameEntity entity)
        {
            return entity.isDestroyed;
        }
    }
}