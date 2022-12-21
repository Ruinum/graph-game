using Ruinum.ECS.Extensions;
using Ruinum.ECS.Utilities;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class RotateByDurationEntityStrategy : EntityStrategy
    {
        public bool ShortWay = false;

        public override bool Process(GameEntity entity)
        {
            if (!entity.hasTime)
            {
                if (Logging) LogErrorNotFound("TimeComponent", (nameof(entity), entity));
                return false;
            }
            if (!entity.hasStartTime)
            {
                if (Logging) LogErrorNotFound("TimeStartComponent", (nameof(entity), entity));
                return false;
            }
            if (!entity.hasRotation)
            {
                if (Logging) LogErrorNotFound("RotationComponent", (nameof(entity), entity));
                return false;
            }
            var owner = entity.GetRootOwnerOrThis();
            var time = entity.time.Value;
            if (time <= 0)
            {
                owner.ReplaceTransformRotationTo(entity.rotation.Value);
                return true;
            }
            var startTime = entity.startTime.Value;
            var lerpValue = (startTime - time) / startTime;
            owner.ReplaceTransformRotationTo(ShortWay
                ? QuaternionUtilities.LerpShortWay(owner.transformRotation.Value, entity.rotation.Value, lerpValue)
                : Quaternion.Lerp(owner.transformRotation.Value, entity.rotation.Value, lerpValue));

            return true;
        }
    }
}