using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public sealed class TargetEntityConfigEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IEntityConfigStrategy Config;

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

            target.ReplaceTargetEntityConfig(config);
            return true;
        }
    }
}