using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class TransformPositionToEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Point;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Point.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound("Vector3", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceTransformPositionTo(result);
            return true;
        }
    }
}