using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public abstract class MovementByMotionLengthStrategy : EntityStrategy
    {
        public sealed override bool Process(GameEntity entity)
        {            
            if ((!entity.hasMoveDistance || !entity.hasTime || !entity.hasVelocity) && !InitializeMotion(entity))
            {
                return false;
            }
            var motionLength = entity.moveDistance.Value;
            if (motionLength <= 0)
            {
                entity.ReplaceVelocity(0);
                return true;
            }
            var newValue = motionLength - (entity.velocity.Value * Time.deltaTime);
            if (newValue < 0)
            {
                entity.ReplaceVelocity(motionLength / Time.deltaTime);
            }
            entity.ReplaceMoveDistance(newValue);
            return true;
        }
        
        protected abstract bool InitializeMotion(GameEntity entity);
    }
}