using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityByConfigStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IEntityConfigStrategy Config = new EntityConfigFromComponentStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy CreatorStrategy = new CurrentEntityTargetStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!Config.TryGet(entity, out var config))
            {
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity));
                return false;
            }

            if (!CreatorStrategy.TryGet(entity, out var creator))
            {
                if(Logging) LogErrorNotFound(nameof(creator), (nameof(entity), entity), (nameof(config), config));
                return false;
            }

            var created = config.Create();
            entity.ReplaceGameCreatedEntity(created);
            created.AddCreatorEntity(creator);
            EntityUtilities.ProcessMainCreator(entity, created);
            return true;
        }
    }
}