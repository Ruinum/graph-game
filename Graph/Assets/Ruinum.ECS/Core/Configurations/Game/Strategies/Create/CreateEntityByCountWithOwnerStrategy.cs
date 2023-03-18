using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityByCountWithOwnerStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Owner = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy ComponentTarget = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy Count;

        public override bool Process(GameEntity entity)
        {
            if (!Owner.TryGet(entity, out var ownerEntity))
            {
                if(Logging) LogErrorNotFound(nameof(ownerEntity), (nameof(entity), entity));
                return false;
            }

            if (!Count.TryGet(entity, out var countValue))
            {
                if(Logging) LogErrorNotFound(nameof(countValue), (nameof(entity), entity), (nameof(ownerEntity), ownerEntity));
                return false;
            }

            if (!ComponentTarget.TryGet(entity, out var componentTarget))
            {
                if(Logging) LogErrorNotFound(nameof(componentTarget), (nameof(entity), entity), (nameof(ownerEntity), ownerEntity), (nameof(countValue), countValue));
                return false;
            }

            if (!componentTarget.hasTargetEntityConfig)
            {
                if(Logging) LogErrorNotFound("TargetEntityConfigComponent", (nameof(entity), entity), (nameof(ownerEntity), ownerEntity), (nameof(countValue), countValue), (nameof(componentTarget), componentTarget));
                return false;
            }

            for (int i = 0, max = (int)countValue; i < max; i++)
            {
                var created = componentTarget.targetEntityConfig.Value.Create(ownerEntity);
                entity.ReplaceGameCreatedEntity(created);
                created.AddCreatorEntity(entity);
                EntityUtilities.ProcessMainCreator(entity, created);
            }
            return true;
        }
    }
}