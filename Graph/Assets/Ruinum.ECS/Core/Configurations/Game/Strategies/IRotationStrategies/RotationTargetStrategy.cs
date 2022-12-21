using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class RotationTargetStrategy : RotationStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, out Quaternion rotation)
        {
            if (!Target.TryGet(entity, out var target))
            {
                rotation = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasRotation)
            {
                rotation = default;
                if(Logging) LogErrorNotFound("RotationComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            rotation = target.rotation.Value;
            return true;
        }
    }
}