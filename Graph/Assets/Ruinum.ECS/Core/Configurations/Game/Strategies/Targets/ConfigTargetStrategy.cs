using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.Find;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ConfigTargetStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IConfigTargetFindStrategy FindStrategy = new RootOwnerHierarchyConfigTargetFindStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IEntityConfigStrategy Config = new SimpleEntityConfigStrategy();

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!Config.TryGet(entity, out var config))
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity));
                return false;
            }

            if (!FindStrategy.TryGet(entity, config, out targetEntity))
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity), (nameof(config), config));
                return false;
            }

            return true;
        }
    }
}