using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ReplaceTargetStrategy : EntityStrategy
    {
        [AssetSelector(Filter = "t:TargetStrategyConfig")][LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [AssetSelector(Filter = "t:TargetStrategyConfig")][LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var targetEntity))
            {
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var targetResult))
            {
                if(Logging) LogErrorNotFound(nameof(targetResult), (nameof(entity), entity), (nameof(targetEntity), targetEntity));
                return false;
            }

            targetEntity.ReplaceGameTarget(targetResult);
            return true;
        }
    }
}