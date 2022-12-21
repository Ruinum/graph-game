using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class DirectionBetweenPointsStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy FromPoint;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy ToPoint;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!FromPoint.TryGet(entity, out var from))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(from), (nameof(entity), entity));
                return false;
            }

            if (!ToPoint.TryGet(entity, out var to))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(to), (nameof(entity), entity), (nameof(from), from));
                return false;
            }

            result = to - @from;
            return true;
        }
    }
}