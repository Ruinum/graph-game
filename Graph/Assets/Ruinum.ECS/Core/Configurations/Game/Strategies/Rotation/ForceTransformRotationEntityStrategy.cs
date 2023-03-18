using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class ForceTransformRotationEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        public RotationStrategy Rotation;
        
        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {                
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }
            if (!target.TryGetTransform(out var transform))
            {
                if(Logging) LogErrorNotFound(nameof(transform), (nameof(entity), entity), (nameof(target), target));
                return false;
            }
            if (!Rotation.TryGet(entity, out var rotation))
            {
                if (Logging) LogErrorNotFound(nameof(rotation), (nameof(entity), entity), (nameof(target), target), (nameof(transform), transform.name));
                return false;
            }
            transform.rotation = rotation;
            target.ReplaceTransformRotation(rotation);
            return true;
        }
    }
}