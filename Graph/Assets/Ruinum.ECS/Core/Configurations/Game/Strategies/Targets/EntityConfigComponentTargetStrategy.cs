using Ruinum.ECS.Configurations.Game.Strategies.Targets.Find;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class EntityConfigComponentTargetStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.LargeLabelWidth)] public IConfigTargetFindStrategy FindStrategy = new RootOwnerHierarchyConfigTargetFindStrategy();
        [LabelWidth(EditorConstants.LargeLabelWidth)] public ITargetStrategy ComponentTarget = new CurrentEntityTargetStrategy();

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!ComponentTarget.TryGet(entity, out var entityConfigTarget))
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound(nameof(entityConfigTarget), (nameof(entity), entity));
                return false;
            }
            if (!entityConfigTarget.hasTargetEntityConfig)
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound("TargetEntityConfigComponent", (nameof(entity), entity), (nameof(entityConfigTarget), entityConfigTarget));
                return false;
            }
            if (!FindStrategy.TryGet(entity, entityConfigTarget.targetEntityConfig.Value, out targetEntity))
            {
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity), (nameof(entityConfigTarget), entityConfigTarget), (nameof(entityConfigTarget.targetEntityConfig.Value.name), entityConfigTarget.targetEntityConfig.Value.name));
                return false;
            }
            return true;
        }
    }
}