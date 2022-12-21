using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class RootOwnerHierarchyTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityConfigStrategy Config = new SimpleEntityConfigStrategy();

        public override bool TryGet(GameEntity entity, List<GameEntity> targets)
        {
            if (!Config.TryGet(entity, out var config))
            {
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity));
                return false;
            }

            if (!TryGetEntitiesByOwner(entity, config, out var targetsSet))
            {
                if(Logging) LogErrorNotFound(nameof(targetsSet), (nameof(entity), entity), (nameof(config), config));
                return false;
            }

            targets.AddRange(targetsSet);
            return true;
        }
    }
}