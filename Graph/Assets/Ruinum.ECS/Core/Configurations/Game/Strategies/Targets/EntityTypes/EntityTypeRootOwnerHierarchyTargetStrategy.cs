using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.EntityTypes
{
    public sealed class EntityTypeRootOwnerHierarchyTargetStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public EntityTypeConfig EntityType;
        
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!Services.EntityIndex.TryGetTarget(entity.GetRootOwnerOrThis(), EntityType, out var target))
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            targetEntity = target;
            return true;
        }
    }
}