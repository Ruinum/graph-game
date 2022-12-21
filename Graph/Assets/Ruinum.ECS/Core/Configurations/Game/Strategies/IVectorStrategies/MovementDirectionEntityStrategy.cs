using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class MovementDirectionEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Strategy = new SimpleVectorStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound(nameof(result), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceMovementDirection(result);
            return true;
        }
    }
}