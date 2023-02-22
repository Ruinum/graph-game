using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class EntityListTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasEntityList)
            {
                if (Logging) LogErrorNotFound("GameEntityListComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            targets.AddRange(target.entityList.Value);
            return true;
        }
    }
}