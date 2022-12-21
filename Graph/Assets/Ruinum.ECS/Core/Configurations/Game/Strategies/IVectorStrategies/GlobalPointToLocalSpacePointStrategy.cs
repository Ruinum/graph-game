using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class GlobalPointToLocalSpacePointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy PositionTarget = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy Point = new SimpleVectorStrategy();

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!PositionTarget.TryGet(entity, out var target))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.TryGetPositionRotation(out var position, out var rotation))
            {
                if (!target.TryGetRootPositionRotation(out position, out rotation))
                {
                    result = default;
                    if (Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(target), target));
                    return false;
                }
            }

            if (!Point.TryGet(entity, out var point))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(target), target), (nameof(position), position), (nameof(rotation), rotation));
                return false;
            }

            result = point.InverseTransformPoint(position, rotation);
            return true;
        }
    }
}