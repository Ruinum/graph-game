using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class MoveDistanceEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy FloatStrategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!FloatStrategy.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound(nameof(result), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceMoveDistance(result);
            return true;
        }
    }
}