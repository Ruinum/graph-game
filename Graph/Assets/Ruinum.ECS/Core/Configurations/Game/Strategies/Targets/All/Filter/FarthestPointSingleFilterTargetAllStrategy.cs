using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class FarthestPointSingleFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Point;

        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            if (!Point.TryGet(entity, out var fromPoint))
            {
                if(Logging) LogErrorNotFound(nameof(fromPoint), (nameof(entity), entity));
                return false;
            }
            if (sourceBuffer.Count == 0)
            {
                if(Logging) LogErrorNotFound("GameEntity for sourceBuffer", (nameof(entity), entity));
                return false;
            }
            var resultEntity = sourceBuffer[0];
            if (!Point.TryGet(resultEntity, out var toPoint))
            {
                if(Logging) LogErrorNotFound(nameof(toPoint), (nameof(entity), entity), (nameof(fromPoint), fromPoint));
                return false;
            }
            var farthestDistance = Vector3.Distance(fromPoint, toPoint);
            for (int i = 1, max = sourceBuffer.Count; i < max; i++)
            {
                var targetEntity = sourceBuffer[i];
                if (!Point.TryGet(targetEntity, out toPoint))
                {
                    continue;
                }
                var distance = Vector3.Distance(fromPoint, toPoint);
                if (farthestDistance < distance)
                {
                    farthestDistance = distance;
                    resultEntity = targetEntity;
                }
            }
            resultBuffer.Add(resultEntity);
            return true;
        }
    }
}