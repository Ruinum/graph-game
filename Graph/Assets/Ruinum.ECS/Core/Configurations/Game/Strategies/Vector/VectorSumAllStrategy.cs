using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VectorSumAllStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy TargetAll;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Vector;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetAll.TryGet(entity, _buffer))
            {
                _buffer.Clear();
                result = default;
                if(Logging) LogErrorNotFound("GameEntity for _buffer", (nameof(entity), entity));
                return false;
            }
            result = Vector3.zero;
            for (int i = 0, max = _buffer.Count; i < max; i++)
            {
                var targetEntity = _buffer[i];
                if (Vector.TryGet(targetEntity, out var vector))
                {
                    result += vector;
                }
            }
            _buffer.Clear();
            return true;
        }
    }
}