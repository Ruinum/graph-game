using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class RotationToDirectionStrategy : RotationStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3 Upward = Vector3.up;

        public override bool TryGet(GameEntity entity, out Quaternion rotation)
        {
            if (!Vector.TryGet(entity, out var direction))
            {
                rotation = default;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity));
                return false;
            }

            if (direction.Equals(Vector3.zero))
            {
                rotation = default;
                if(Logging) LogErrorNotFound("direction is Vector3.zero", (nameof(entity), entity), (nameof(direction), direction));
                return false;
            }

            rotation = Quaternion.LookRotation(direction, Upward);
            return true;
        }
    }
}