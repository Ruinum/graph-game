using Ruinum.ECS.Configurations.Game.Strategies.Rotation;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class RotationToEulerAnglesVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public RotationStrategy Rotation;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Rotation.TryGet(entity, out var rotation))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(Rotation), (nameof(entity), entity));
                return false;
            }

            result = rotation.eulerAngles;
            return true;
        }
    }
}