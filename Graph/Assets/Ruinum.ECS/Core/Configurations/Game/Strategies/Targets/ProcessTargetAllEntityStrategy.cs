using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ProcessTargetAllEntityStrategy: EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy Strategy;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }
        
        public override bool Process(GameEntity entity)
        {
            if (!Strategy.TryGet(entity, _buffer))
            {
                _buffer.Clear();
                if(Logging) LogErrorNotFound("GameEntity for _buffer", (nameof(entity), entity));
                return false;
            }

            _buffer.Clear();
            return true;
        }
    } 
}