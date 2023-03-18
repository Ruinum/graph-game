using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class RotationEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public RotationStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Strategy.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound(nameof(result), (nameof(entity), entity));
                return false;
            }
            entity.ReplaceRotation(result);
            return true;
        }
    }
}