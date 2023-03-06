using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class FindDepthFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [AssetSelector(Filter = "t:TargetStrategyConfig")][LabelWidth(EditorConstants.MiddleLabelWidth)]  public ITargetStrategy Strategy;

        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            for (int i = 0, max = sourceBuffer.Count; i < max; i++)
            {
                if (Strategy.TryGet(sourceBuffer[i], out var target))
                {
                    resultBuffer.Add(target);
                }
            }
            return true;
        }
    }
}