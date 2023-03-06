using System.Collections.Generic;
using Ruinum.ECS.Configurations.Conditions;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class DistancePointFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy SourcePoint;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IVectorStrategy TargetPoint;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EqualityType Equality;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy Distance;

        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            if (sourceBuffer.Count == 0)
            {
                if(Logging) LogErrorNotFound("GameEntity fot sourceBuffer", (nameof(entity), entity));
                return false;
            }

            if (!SourcePoint.TryGet(entity, out var fromPoint))
            {
                if(Logging) LogErrorNotFound(nameof(fromPoint), (nameof(entity), entity));
                return false;
            }

            if (!Distance.TryGet(entity, out var distance))
            {
                if(Logging) LogErrorNotFound(nameof(distance), (nameof(entity), entity), (nameof(fromPoint), fromPoint));
                return false;
            }

            for (int i = 0, max = sourceBuffer.Count; i < max; i++)
            {
                var targetEntity = sourceBuffer[i];
                if (!TargetPoint.TryGet(targetEntity, out var point))
                {
                    continue;
                }
                var targetDistance = Vector3.Distance(fromPoint, point);
                if (ConditionUtilities.IsConditionTrue(Equality, distance, targetDistance))
                {
                    resultBuffer.Add(targetEntity);
                }
            }
            return resultBuffer.Count > 0;
        }
    }
}