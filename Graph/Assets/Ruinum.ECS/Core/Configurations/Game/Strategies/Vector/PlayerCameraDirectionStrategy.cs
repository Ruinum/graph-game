using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class PlayerCameraDirectionStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 LocalDirection;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            var gameContext = Contexts.sharedInstance.game;
            if (!gameContext.isCamera)
            {
                result = default;
                if (Logging) LogErrorNotFound("PlayerCameraComponent");
                return false;
            }
            var camera = gameContext.cameraEntity;
            if (!camera.hasTransformPosition)
            {
                result = default;
                if (Logging) LogErrorNotFound("TransformPositionComponent");
                return false;
            }

            if (!camera.hasTransformRotation)
            {
                result = default;
                if (Logging) LogErrorNotFound("TransformRotationComponent");
                return false;
            }

            result = LocalDirection.TransformDirection(camera.transformPosition.Value, camera.transformRotation.Value);
            return true;
        }
    }
}