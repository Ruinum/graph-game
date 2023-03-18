using Ruinum.ECS.Configurations.Game.Strategies.Rotation;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class RotationSpaceVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public RotationStrategy Rotation;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Rotation.TryGet(entity, out var rotation))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(rotation), (nameof(entity), entity));
                return false;
            }

            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity), (nameof(rotation), rotation));
                return false;
            }

            result = vector.TransformDirection(Vector3.zero, rotation);
            return true;
        }
    }
}