using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ListFilterTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFilterTargetAllStrategy Strategy;
        private List<GameEntity> _buffer;

        protected override void OnInitialize()
        {
            _buffer = new List<GameEntity>();
        }
        
        public override bool TryGet(GameEntity entity, List<GameEntity> resultBuffer)
        {
            if (!Strategy.TryGet(entity, resultBuffer, _buffer))
            {
                if(Logging) LogErrorNotFound("GameEntity for _buffer", (nameof(entity), entity));
                return false;
            }
            resultBuffer.Clear();
            resultBuffer.AddRange(_buffer);
            _buffer.Clear();
            return true;
        }
    }
}