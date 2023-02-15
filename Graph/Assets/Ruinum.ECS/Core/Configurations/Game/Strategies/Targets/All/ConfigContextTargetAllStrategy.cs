using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ConfigContextTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityConfigStrategy Config;

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            if (!Config.TryGet(entity, out var config))
            {
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity));
                return false;
            }
            var entities = Contexts.game.GetEntitiesWithConfigIndex(config.ConfigIndex);
            targets.AddRange(entities);
            return true;
        }
    }
}