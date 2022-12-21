using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class MaxValueFromTargetAllStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy Targets;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Value;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Targets.TryGet(entity, _buffer))
            {
                _buffer.Clear();
                value = default;
                if(Logging) LogErrorNotFound("GameEntity in _buffer", (nameof(entity), entity));
                return false;
            }
            value = float.MinValue;
            var valueExists = false;
            for (int i = 0, max = _buffer.Count; i < max; i++)
            {
                if (Value.TryGet(_buffer[i], out var bufferValue) && (!valueExists || bufferValue > value))
                {
                    valueExists = true;
                    value = bufferValue;
                }
            }
            _buffer.Clear();
            return valueExists;
        }
    }
}