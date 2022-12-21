using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class FirstFromTargetAllStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy Strategy;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }
        
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!Strategy.TryGet(entity, _buffer) || _buffer.Count == 0)
            {
                targetEntity = default;
                _buffer.Clear();
                if(Logging) LogErrorNotFound("GameEntity for _buffer", (nameof(entity), entity));
                return false;
            }

            targetEntity = _buffer[0];
            _buffer.Clear();
            return true;
        }
    }
}