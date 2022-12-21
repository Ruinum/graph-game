using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LocalPositionToPointVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Point;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!entity.GetRootOwnerOrThis().TryGetPosition(out var position))
            {
                result = default;
                if(Logging) LogErrorNotFound($"RootOwner {nameof(position)}", (nameof(entity), entity));
                return false;
            }

            if (!Point.TryGet(entity, out var point))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(point), (nameof(entity), entity), (nameof(position), position));
                return false;
            }

            result = point - position;
            return true;
        }
    }
}
