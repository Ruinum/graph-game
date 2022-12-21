using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityTargetFromComponentStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy OwnerStrategy = new TargetFromComponentStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy ComponentTarget = new CurrentEntityTargetStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!OwnerStrategy.TryGet(entity, out var ownerEntity))
            {
                if(Logging) LogErrorNotFound(nameof(ownerEntity), (nameof(entity), entity));
                return false;
            }

            if (!ComponentTarget.TryGet(entity, out var componentTarget))
            {
                if(Logging) LogErrorNotFound(nameof(componentTarget), (nameof(entity), entity), (nameof(ownerEntity), ownerEntity));
                return false;
            }

            if (!componentTarget.hasTargetEntityConfig)
            {
                if(Logging) LogErrorNotFound("TargetEntityConfigComponent", (nameof(entity), entity), (nameof(ownerEntity), ownerEntity), (nameof(componentTarget), componentTarget));
                return false;
            }

            var created = componentTarget.targetEntityConfig.Value.Create(ownerEntity);
            entity.ReplaceGameCreatedEntity(created);
            created.AddCreatorEntity(entity);
            EntityUtilities.ProcessMainCreator(entity, created);
            return true;
        }
    }
}