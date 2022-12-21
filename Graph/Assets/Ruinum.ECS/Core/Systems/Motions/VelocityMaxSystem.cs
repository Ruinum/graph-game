using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class VelocityMaxSystem : ReactiveSystemExtended<GameEntity>
    {
        public VelocityMaxSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.VelocityMax));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasVelocity && entity.hasVelocityMax;
        }

        protected override void Execute(GameEntity entity)
        {
            entity.ReplaceVelocity(entity.velocity.Value.ClampMax(entity.velocityMax.Value));
        }
    }
}