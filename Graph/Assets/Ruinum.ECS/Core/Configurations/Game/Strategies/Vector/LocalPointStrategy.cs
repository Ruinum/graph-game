using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LocalPointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 LocalPoint;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.TryGetRootPositionRotation(out var position, out var rotation))
            {
                result = default;
                if(Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            result = VectorUtilities.TransformPoint(LocalPoint, position, rotation);
            return true;
        }
    }
}