using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VelocityVectorByRotationStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Target.TryGet(entity, out var target))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasVelocityVector)
            {
                result = default;
                if (Logging) LogErrorNotFound("VelocityVectorComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            result = target.velocityVector.Value.TransformDirection(Vector3.zero, entity.hasRotation ? entity.rotation.Value : Quaternion.identity);
            return true;
        }
    }
}