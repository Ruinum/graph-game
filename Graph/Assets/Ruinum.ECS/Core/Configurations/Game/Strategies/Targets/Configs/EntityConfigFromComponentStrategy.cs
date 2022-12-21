using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public sealed class EntityConfigFromComponentStrategy : EntityConfigStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target = new CurrentEntityTargetStrategy();

        public override bool TryGet(GameEntity entity, out GameEntityConfig config)
        {
            if (!Target.TryGet(entity, out var target))
            {
                config = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasTargetEntityConfig)
            {
                config = default;
                if(Logging) LogErrorNotFound("TargetEntityConfigComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            config = target.targetEntityConfig.Value;
            return true;
        }
    }
}