using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class PositionOrPositionToValueStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Target.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }
            
            if (target.hasTransformPositionTo)
            {
                result = target.transformPositionTo.Position;
                return true;
            }
            
            if (target.hasTransformPosition)
            {
                result = target.transformPosition.Value;
                return true;
            }
            
            result = default;
            if(Logging) LogErrorNotFound("TransformPositionToComponent or TransformPositionComponent", (nameof(entity), entity));
            return false;            
        }
    }
}