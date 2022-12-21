using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class TargetVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Target;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy Strategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Target.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(target, out result))
            {
                result = default;
                if(Logging) LogErrorNotFound("Vector3", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            return true;
        }
    }
}