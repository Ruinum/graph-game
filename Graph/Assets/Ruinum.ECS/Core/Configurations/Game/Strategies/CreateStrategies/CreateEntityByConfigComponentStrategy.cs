using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityByConfigComponentStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy ComponentTarget = new CurrentEntityTargetStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!ComponentTarget.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasTargetEntityConfig)
            {
                if(Logging) LogErrorNotFound("TargetEntityConfigComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            var created = target.targetEntityConfig.Value.Create();
            entity.ReplaceGameCreatedEntity(created);
            created.AddCreatorEntity(entity.GetRootOwnerOrThis());
            EntityUtilities.ProcessMainCreator(entity, created);
            return true;
        }
    }
}