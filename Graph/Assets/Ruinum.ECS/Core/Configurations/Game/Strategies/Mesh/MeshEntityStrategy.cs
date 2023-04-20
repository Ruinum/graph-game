using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Mesh
{
    public sealed class MeshEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IMeshStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var reference))
            {
                if(Logging) LogErrorNotFound(nameof(reference), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceMesh(reference);
            return true;
        }
    }
}