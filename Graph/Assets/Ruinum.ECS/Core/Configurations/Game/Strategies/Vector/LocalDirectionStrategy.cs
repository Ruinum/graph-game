using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LocalDirectionStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 LocalDirection;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.TryGetRootPositionRotation(out var position, out var rotation))
            {
                result = default;
                if (Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            result = LocalDirection.TransformDirection(position, rotation);
            return true;
        }
    }
}