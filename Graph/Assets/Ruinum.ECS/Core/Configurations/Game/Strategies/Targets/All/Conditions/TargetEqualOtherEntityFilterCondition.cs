using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    public sealed class TargetEqualOtherEntityFilterCondition : EntityFilterCondition
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy First;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Second;

        protected override bool IsTrue(GameEntity entity, GameEntity target)
        {
            if (!First.TryGet(entity, out var first))
            {
                if(Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
                return false;
            }
            if (!Second.TryGet(target, out var second))
            {
                if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
                return false;
            }
            return first == second;
        }
    }
}