using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class InputCameraDirectionVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 ScaleVector = Vector3.one;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public bool Normalized = true;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Contexts.game.cameraEntity.TryGetPositionRotation(out var position, out var rotation))
            {
                result = default;
                Debug.Log(Contexts.game.cameraEntity);
                if (Logging) LogErrorNotFound("PlayerCamera");
                return false;
            }

            var input = Contexts.sharedInstance.game.services.Instance.Input;
            var matrix = VectorUtilities.Matrix(position, rotation, Vector3.one);
            result = input.GetPlayerMoveY() * matrix.MultiplyVector(Vector3.forward) + input.GetPlayerMoveX() * matrix.MultiplyVector(Vector3.right);

            if (Normalized)
            {
                result = result.normalized;
            }

            result = result.GetScaled(ScaleVector);
            return true;
        }
    }
}