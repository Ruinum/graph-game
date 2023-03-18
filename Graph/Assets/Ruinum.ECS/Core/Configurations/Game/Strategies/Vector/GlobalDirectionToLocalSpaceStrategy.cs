using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class GlobalDirectionToLocalSpaceStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy Direction = new SimpleVectorStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy LocalSpaceTarget = new CurrentEntityTargetStrategy();

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!LocalSpaceTarget.TryGet(entity, out var targetEntity))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                return false;
            }

            if (!targetEntity.TryGetRootPositionRotation(out var position, out var rotation))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound($"{nameof(position)} or {nameof(rotation)}", (nameof(entity), entity), (nameof(targetEntity), targetEntity));
                return false;
            }

            if (!Direction.TryGet(entity, out var direction))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity), (nameof(targetEntity), targetEntity), (nameof(position), position), (nameof(rotation), rotation));
                return false;
            }

            result = default;//direction.InverseTransformDirection(position, rotation);
            return true;
        }
    }
}