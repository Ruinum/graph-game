using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class EntityTypeRootOwnerHierarchyTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EntityTypeConfig EntityType;
        
        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            if (!Services.EntityIndex.TryGetTargets(entity.GetRootOwnerOrThis(), EntityType, out var targetsSet))
            {
                if(Logging) LogErrorNotFound($"RootOwner {nameof(targetsSet)} for EntityType", (nameof(entity), entity));
                return false;
            }
            targets.AddRange(targetsSet);
            return true;
        }
    }
}