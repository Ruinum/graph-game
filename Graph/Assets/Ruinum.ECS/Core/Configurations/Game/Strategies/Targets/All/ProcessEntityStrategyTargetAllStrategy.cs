using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ProcessEntityStrategyTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public bool FreeResult;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityStrategy Strategy;

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (!Strategy.Process(targets[i]) && !FreeResult)
                {
                    if(Logging) LogErrorNotFound($"targets[{i}] and !FreeResult", (nameof(entity), entity));
                    return false;
                }
            }
            return true;
        }
    }
}