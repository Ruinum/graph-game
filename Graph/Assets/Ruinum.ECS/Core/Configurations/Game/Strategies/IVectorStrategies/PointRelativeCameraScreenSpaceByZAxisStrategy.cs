using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class PointRelativeCameraScreenSpaceByZAxisStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy SourcePoint = new PointStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy SourcePointOffset = new SimpleVectorStrategy {Vector = new Vector3(0f, 0f, 0f)};
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy PlaneVerticalSize = new SimpleFloatValueStrategy();

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            //if (!Contexts.game.isPlayerCamera)
            //{
            //    result = Vector3.zero;
            //    if(Logging) LogErrorNotFound("PlayerCameraComponent");
            //    return false;
            //}

            //if (!Contexts.game.playerCameraEntity.TryGetTransform(out var transform))
            //{
            //    result = Vector3.zero;
            //    if(Logging) LogErrorNotFound($"playerCameraEntity {nameof(transform)}", (nameof(entity), entity));
            //    return false;
            //}

            //if (!SourcePoint.TryGet(entity, out var sourcePoint))
            //{
            //    result = Vector3.zero;
            //    if(Logging) LogErrorNotFound(nameof(sourcePoint), (nameof(entity), entity), (nameof(transform), transform));
            //    return false;
            //}

            //if (!SourcePointOffset.TryGet(entity, out var sourcePointOffset))
            //{
            //    result = Vector3.zero;
            //    if(Logging) LogErrorNotFound(nameof(sourcePointOffset), (nameof(entity), entity), (nameof(transform), transform), (nameof(sourcePoint), sourcePoint));
            //    return false;
            //}

            //if (!PlaneVerticalSize.TryGet(entity, out var planeVerticalSize))
            //{
            //    result = Vector3.zero;
            //    if(Logging) LogErrorNotFound(nameof(planeVerticalSize), (nameof(entity), entity), (nameof(transform), transform), (nameof(sourcePoint), sourcePoint), (nameof(sourcePointOffset), sourcePointOffset));
            //    return false;
            //}

            //var cameraPosition = transform.position;
            //var yRotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
            //var cameraSpacePoint = sourcePoint.InverseTransformPoint(cameraPosition, yRotation) + sourcePointOffset;
            //var planeSourcePoint = cameraSpacePoint.TransformPosition(cameraPosition, yRotation);
            //var normal = cameraPosition.GetScaledVertical() - planeSourcePoint.GetScaledVertical();
            //var planeIntersectionPoint = VectorUtilities.PlaneIntersection(planeSourcePoint, normal.normalized,
            //    cameraPosition, transform.forward);
            //result = planeIntersectionPoint.InverseTransformPoint(planeSourcePoint, yRotation);
            //result.y = Mathf.Clamp(result.y, -(planeVerticalSize / 2), planeVerticalSize / 2);
            //result = result.TransformPosition(planeSourcePoint, yRotation);
            result = default;
            return true;
        }
    }
}