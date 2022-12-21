using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class DirectionToPointStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy Point = new PointStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public Vector3 ScaleVector = Vector3.one;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Point.TryGet(entity, out var point))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity));
                return false;
            }

            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                result = Vector3.zero;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity), (nameof(point), point));
                return false;
            }

            result = point - position;
            result.Scale(ScaleVector);
            result.Normalize();
            return true;
        }
    }
}