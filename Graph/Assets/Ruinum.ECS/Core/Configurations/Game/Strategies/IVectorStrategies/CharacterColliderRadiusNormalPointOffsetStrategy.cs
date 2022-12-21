using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class CharacterColliderRadiusByDirectionPointOffsetStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy PointStrategy = new PointStrategy {TargetStrategy = new CurrentEntityTargetStrategy()};
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy DirectionStrategy;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!PointStrategy.TryGet(entity, out var point))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity));
                return false;
            }

            if (!DirectionStrategy.TryGet(entity, out var direction))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity), (nameof(point), point));
                return false;
            }

            if (!entity.GetRootOwnerOrThis().TryGetCharacterController(out var characterController))
            {
                result = default;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(characterController)}", (nameof(entity), entity), (nameof(point), point), (nameof(direction), direction));
                return false;
            }

            result = point + direction * (characterController.radius + ColliderConstants.MinNormalOffset);
            return true;
        }
    }
}