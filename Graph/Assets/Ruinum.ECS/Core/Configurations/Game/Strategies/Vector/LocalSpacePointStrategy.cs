using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LocalSpacePointStrategy : VectorStrategy
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

            if (!target.TryGetRootPositionRotation(out var position, out var rotation))
            {
                result = default;
                if (Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!Point.TryGet(entity, out var point))
            {
                result = default;
                if (Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(target), target), (nameof(position), position), (nameof(rotation), rotation));
                return false;
            }

            result = point.TransformPosition(position, rotation);
            return true;
        }
    }
}