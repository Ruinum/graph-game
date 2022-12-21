using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformInstantRotationSystem : ReactiveSystemExtended<GameEntity>
    {
        public TransformInstantRotationSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Rotation);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasRotation && entity.isInstantRotation && entity.HasRootOwner;
        }

        protected override void Execute(GameEntity entity)
        {
            entity.RootOwnerEntity.ReplaceTransformRotationTo(entity.rotation.Value);
        }
    }
}