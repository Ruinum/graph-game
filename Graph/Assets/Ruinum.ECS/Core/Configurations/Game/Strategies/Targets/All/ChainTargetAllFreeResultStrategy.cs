using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ChainTargetAllFreeResultStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy[] Strategies = new ITargetAllStrategy[0];

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                Strategies[i].TryGet(entity, targets);
            }
            return true;
        }
    }
}