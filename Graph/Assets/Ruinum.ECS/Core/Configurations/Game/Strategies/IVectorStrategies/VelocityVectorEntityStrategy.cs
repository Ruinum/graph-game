using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class VelocityVectorEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Strategy.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound("Vector3", (nameof(entity), entity));
                return false;
            }

            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity), (nameof(result), result));
                return false;
            }

            target.ReplaceVelocityVector(result);
            return true;
        }
    }
}