using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class NearestPointByDistanceSingleFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy SelfPoint;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy TargetPoint;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EqualityType Equality;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy Distance;
        private List<(GameEntity entity, float distance)> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<(GameEntity entity, float distance)>();
        }
        
        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            if (!SelfPoint.TryGet(entity, out var fromPoint))
            {
                if(Logging) LogErrorNotFound(nameof(fromPoint), (nameof(entity), entity));
                return false;
            }

            if (!Distance.TryGet(entity, out var distance))
            {
                if(Logging) LogErrorNotFound(nameof(distance), (nameof(entity), entity), (nameof(fromPoint), fromPoint));
                return false;
            }

            if (sourceBuffer.Count == 0)
            {
                if(Logging) LogErrorNotFound("GameEntity for sourceBuffer");
                return false;
            }
            if (!FilterByDistance(sourceBuffer, fromPoint, distance))
            {
                if(Logging) LogErrorNotFound("targetEntity with targetPoint in sourceBuffer", (nameof(entity), entity));
                return false;
            }
            FilterByNearest(resultBuffer);
            _buffer.Clear();
            return true;
        }

        private bool FilterByDistance(List<GameEntity> sourceBuffer, Vector3 fromPoint, float distance)
        {
            for (int i = 0, max = sourceBuffer.Count; i < max; i++)
            {
                var targetEntity = sourceBuffer[i];
                if (!TargetPoint.TryGet(sourceBuffer[i], out var targetPoint))
                {
                    continue;
                }
                var resultDistance = Vector3.Distance(fromPoint, targetPoint);
                if (ConditionUtilities.IsConditionTrue(Equality, distance, resultDistance))
                {
                    _buffer.Add((targetEntity, resultDistance));
                }
            }
            return _buffer.Count > 0;
        }

        private void FilterByNearest(List<GameEntity> resultBuffer)
        {
            var resultEntity = _buffer[0];
            for (int i = 1, max = _buffer.Count; i < max; i++)
            {
                var targetEntity = _buffer[i];
                if (resultEntity.distance > targetEntity.distance)
                {
                    resultEntity = targetEntity;
                }
            }
            resultBuffer.Add(resultEntity.entity);
        }
    }
}