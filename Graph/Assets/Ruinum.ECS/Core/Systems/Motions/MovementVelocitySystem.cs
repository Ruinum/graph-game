using Entitas;
using UnityEngine;

namespace Ruinum.ECS.Core.Systems
{
    public class MovementVelocitySystem : GroupExecuteSystem<GameEntity>
    {
        public MovementVelocitySystem(IContext<GameEntity> context) : base(context, GameMatcher.MovementDirection) { }
        
        protected override void Execute(GameEntity entity)
        {
            if (entity.hasMovementDirection && entity.hasVelocity)
            {
                entity.ReplaceMovement(entity.velocity.Value * (entity.hasVelocityModifier ? entity.velocityModifier.Value : 1f) * entity.movementDirection.Value);
            }
        }
    }
}