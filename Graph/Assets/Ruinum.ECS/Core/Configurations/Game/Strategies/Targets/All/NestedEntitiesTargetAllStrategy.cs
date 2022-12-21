using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class NestedEntitiesTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            if (!Target.TryGet(entity, out var owner))
            {
                if(Logging) LogErrorNotFound(nameof(owner), (nameof(entity), entity));
                return false;
            }
            //targets.AddRange(Contexts.game.GetEntitiesWithGameOwner(owner));
            return true;
        }
    }
}