using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class LastFromTargetAllVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetAllStrategy TargetAll;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy Vector;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!TargetAll.TryGet(entity, _buffer) || _buffer.Count == 0)
            {
                _buffer.Clear();
                result = default;
                if(Logging) LogErrorNotFound("GameEntity for _buffer", (nameof(entity), entity));
                return false;
            }
            var targetEntity = _buffer[_buffer.Count - 1];
            _buffer.Clear();
            return Vector.TryGet(targetEntity, out result);
        }
    }
}