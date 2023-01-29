using UnityEngine;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class AccelerationSystem : GroupExecuteSystem<GameEntity>
    {
        public AccelerationSystem(GameContext context) : base(context, GameMatcher.Acceleration)
        {
        }

        protected override void Execute(GameEntity entity)
        {
            entity.ReplaceVelocity((entity.hasVelocity ? entity.velocity.Value : 0) + entity.acceleration.Value * Time.deltaTime);
        }
    }
}