using Ruinum.ECS.Extensions;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformPositionToSystem : ReactiveSystemExtended<GameEntity>
    {
        public TransformPositionToSystem(GameContext context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TransformPositionTo);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTransformPositionTo;
        }

        protected override void Execute(GameEntity e)
        {
            if (!e.TryGetTransform(out var transform))
            {
                return;
            }
            var position = e.transformPositionTo.Position;
            transform.position = position;
            e.ReplaceTransformPosition(position);
        }
    }
}