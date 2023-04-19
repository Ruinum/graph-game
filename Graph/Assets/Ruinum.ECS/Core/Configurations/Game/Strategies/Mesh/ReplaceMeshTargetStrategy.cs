using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Prefab
{
    public sealed class ReplaceMeshTargetStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IPrefabStrategy Mesh;
        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if(!Mesh.TryGet(entity, out var mesh))
            {
                if (Logging) LogErrorNotFound(nameof(target.hasMesh), (nameof(entity), entity));
                return false;
            }

            //target.ReplaceMesh(mesh); 
            return true;
        }
    }
}