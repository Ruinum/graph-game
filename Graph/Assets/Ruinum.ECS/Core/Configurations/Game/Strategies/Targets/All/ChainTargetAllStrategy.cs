using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ChainTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetAllStrategy[] Strategies = new ITargetAllStrategy[0];

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                if (!Strategies[i].TryGet(entity, targets))
                {
                    if(Logging) LogErrorNotFound($"{nameof(targets)} in Strategies[{i}]", (nameof(entity), entity));
                    return false;
                }

                if (targets.Count == 0)
                {
                    if(Logging) LogErrorNotFound("GameEntity for targets", (nameof(entity), entity), (nameof(targets), targets));
                    return false;
                }
            }  
            return true;
        } 
    }
}