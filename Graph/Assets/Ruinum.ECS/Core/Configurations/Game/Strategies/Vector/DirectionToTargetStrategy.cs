using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class DirectionToTargetStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 ScaleVector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.GetRootOwnerOrThis().TryGetPosition(out var targetPosition))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(targetPosition)}", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity), (nameof(target), target), (nameof(targetPosition), targetPosition));
                return false;
            }

            result = targetPosition - position;
            result.Scale(ScaleVector);
            result.Normalize();
            return true;
        }
    }
}