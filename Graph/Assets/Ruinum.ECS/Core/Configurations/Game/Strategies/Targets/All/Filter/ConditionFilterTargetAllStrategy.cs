using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class ConditionFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityFilterCondition Condition;

        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            for (int i = 0, max = sourceBuffer.Count; i < max; i++)
            {
                var gameEntity = sourceBuffer[i];
                if (Condition.IsConditionTrue(entity, gameEntity))
                {
                    resultBuffer.Add(gameEntity);
                }
            }
            return true;
        }
    }
}