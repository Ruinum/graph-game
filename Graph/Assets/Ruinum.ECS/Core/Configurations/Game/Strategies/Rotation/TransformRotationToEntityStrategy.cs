using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class TransformRotationToEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public RotationStrategy Strategy;

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

            target.ReplaceTransformRotationTo(result);
            return true;
        }
    }
}