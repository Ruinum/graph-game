using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ContextTargetStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityConfigStrategy Config = new SimpleEntityConfigStrategy();

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (!Config.TryGet(entity, out var config))
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity));
                return false;
            }
            var entities = Contexts.game.GetEntitiesWithConfigIndex(config.ConfigIndex);
            if (entities.Count == 0)
            {
                targetEntity = default;
                return false;
            }
            return entities.TryGetFirst(out targetEntity);
        }
    }
} 