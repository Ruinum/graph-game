using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class LocalEulerAnglesRotationStrategy : RotationStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3 LocalRotation;

        public override bool TryGet(GameEntity entity, out Quaternion rotation)
        {
            if (!entity.GetRootOwnerOrThis().TryGetRotation(out var objectRotation))
            {
                rotation = default;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(objectRotation)}");
                return false;
            }

            rotation = Quaternion.Euler(objectRotation.eulerAngles + LocalRotation);
            return true;
        }
    }
}