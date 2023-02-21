using Ruinum.ECS.Extensions;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public sealed class MovementToPointByDurationStrategy : MovementByMotionLengthStrategy
    {
        protected override bool InitializeMotion(GameEntity entity)
        {
            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                if(Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasStartTime)
            {
                if(Logging) LogErrorNotFound("TimeStartComponent", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasPoint)
            {
                if(Logging) LogErrorNotFound("PointComponent", (nameof(entity), entity));
                return false;
            }

            var distance = Vector3.Distance(position, entity.point.Value);
            var velocity = distance / entity.time.Value;
            if (velocity <= 0)
            {
                velocity = distance / Time.deltaTime;
            }
            entity.ReplaceVelocity(velocity);
            entity.ReplaceMoveDistance(distance);
            return true;
        }
    }
}