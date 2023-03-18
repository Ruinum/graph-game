using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ProjectionDirectionOnPlaneVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy Direction;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy PlaneNormal;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy Upward = new SimpleVectorStrategy{ Vector = new Vector3(0,1,0)};
        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Direction.TryGet(entity, out var direction))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(direction), (nameof(entity), entity));
                return false;
            }

            if (!PlaneNormal.TryGet(entity, out var normal))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(normal), (nameof(entity), entity), (nameof(direction), direction));
                return false;
            }

            if (!Upward.TryGet(entity, out var upward))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(upward), (nameof(entity), entity), (nameof(direction), direction), (nameof(normal), normal));
                return false;
            }

            var directionRight = Vector3.Cross(direction, upward);
            result = Vector3.Cross(normal, directionRight).normalized;
            return true;
        }
    }
}