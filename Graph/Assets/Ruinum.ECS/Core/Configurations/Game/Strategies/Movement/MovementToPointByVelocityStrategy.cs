using Ruinum.ECS.Extensions;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public sealed class MovementToPointByVelocityStrategy : MovementByMotionLengthStrategy
    {
        protected override bool InitializeMotion(GameEntity entity)
        {
            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                if (Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasVelocity)
            {
                if (Logging) LogErrorNotFound("VelocityComponent", (nameof(entity), entity));
                return false;
            }

            if (!entity.hasPoint)
            {
                if (Logging) LogErrorNotFound("PointComponent", (nameof(entity), entity));
                return false;
            }

            var distance = Vector3.Distance(position, entity.point.Value);
            entity.ReplaceTime(distance / entity.velocity.Value);
            entity.ReplaceMoveDistance(distance);
            return true;
        }
    }
}