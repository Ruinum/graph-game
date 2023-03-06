using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class ChainFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFilterTargetAllStrategy[] Strategies;

        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            var length = Strategies.Length;
            for (int i = 0; i < length - 1; i++)
            {
                if (!TryProcessStrategies(entity, sourceBuffer, resultBuffer, i))
                {
                    if(Logging) LogErrorNotFound($"resultBuffer empty or Strategies[{i}]", (nameof(entity), entity));
                    return false;
                }
                sourceBuffer.Clear();
                sourceBuffer.AddRange(resultBuffer);
                resultBuffer.Clear();
            }
            return TryProcessStrategies(entity, sourceBuffer, resultBuffer, length - 1);
        }

        private bool TryProcessStrategies(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer, int strategyIndex)
        {
            return Strategies[strategyIndex].TryGet(entity, sourceBuffer, resultBuffer) && resultBuffer.Count > 0;
        }
    }
}