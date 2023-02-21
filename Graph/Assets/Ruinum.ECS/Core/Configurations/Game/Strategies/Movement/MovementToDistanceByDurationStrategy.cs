using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public sealed class MovementToDistanceByDurationStrategy : MovementByMotionLengthStrategy
    {
        protected override bool InitializeMotion(GameEntity entity)
        {
            if (!entity.hasMoveDistance)
            {
                if(Logging) LogErrorNotFound("MoveDistanceComponent", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasStartTime)
            {
                if(Logging) LogErrorNotFound("TimeStartComponent", (nameof(entity), entity));
                return false;
            }

            var time = entity.startTime.Value;
            var distance = entity.moveDistance.Value;
            entity.ReplaceVelocity(distance / (time <= 0f ? Time.deltaTime : time));
            return true;
        }
    }
}