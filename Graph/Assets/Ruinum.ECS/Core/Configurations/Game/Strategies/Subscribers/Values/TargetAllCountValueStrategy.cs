using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class TargetAllCountValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy Target;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }
        
        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Target.TryGet(entity, _buffer))
            {
                _buffer.Clear();
                value = default;
                if(Logging) LogErrorNotFound("GameEntity in _buffer", (nameof(entity), entity));
                return false;
            }

            value = _buffer.Count;
            _buffer.Clear();
            return true;
        }
    }
}