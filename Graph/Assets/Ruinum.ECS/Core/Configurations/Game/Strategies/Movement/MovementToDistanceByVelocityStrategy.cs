using Ruinum.ECS.Core.Systems.Log;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public sealed class MovementToDistanceByVelocityStrategy : MovementByMotionLengthStrategy
    {
        protected override bool InitializeMotion(GameEntity entity)
        {
            if (!entity.hasVelocity)
            {
                if(Logging) LogErrorNotFound("VelocityComponent", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasMoveDistance)
            {
                if(Logging) LogErrorNotFound("MoveDistanceComponent", (nameof(entity), entity));
                return false;
            }

            var velocity = entity.velocity.Value;
            if (velocity <= 0)
            {
                if(Logging) LogError("Velocity for motion must be greater then zero.", (nameof(entity), entity));
                return false;
            }
            var distance = entity.moveDistance.Value;
            entity.ReplaceTime(distance / velocity);
            return true;
        }
    }
}