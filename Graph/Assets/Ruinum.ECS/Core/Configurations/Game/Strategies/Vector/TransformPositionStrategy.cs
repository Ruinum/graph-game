using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class TransformPositionStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy TargetStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetStrategy.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.TryGetPosition(out result))
            {
                result = default;
                if(Logging) LogErrorNotFound("Vector3", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            return true;
        }
    }
}