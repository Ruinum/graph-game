using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class ChildTransformByConfigEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityConfigStrategy Config = new SimpleEntityConfigStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }
            if (!Config.TryGet(entity, out var config))
            {
                if(Logging) LogErrorNotFound(nameof(config), (nameof(entity), entity), (nameof(target), target));
                return false;
            }
            target.ReplaceChildTransformByConfig(config);
            return true;
        }
    }
} 