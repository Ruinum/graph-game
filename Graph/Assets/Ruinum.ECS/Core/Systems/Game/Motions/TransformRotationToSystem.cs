using Ruinum.ECS.Extensions;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformRotationToSystem : ReactiveSystemExtended<GameEntity>
    {
        public TransformRotationToSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TransformRotationTo);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTransformRotationTo;
        }

        protected override void Execute(GameEntity entity)
        {
            if (!entity.TryGetTransform(out var transform))
            {
                return;
            }
            var rotation = entity.transformRotationTo.Value;
            transform.rotation = rotation;
            entity.ReplaceTransformRotation(rotation);
        }
    }
}