using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VelocityVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Target.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasVelocityVector)
            {
                result = default;
                if(Logging) LogErrorNotFound("VelocityVectorComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            result = target.velocityVector.Value;
            return true;
        }
    }
}
