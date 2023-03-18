using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed  class TransformRotationStrategy : RotationStrategy
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
            if (!target.TryGetRotation(out rotation))
            {
                if(Logging) LogErrorNotFound("TransformRotationComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }
            return true;
        }
    }
}