using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class BoxColliderSizeVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Target.TryGet(entity, out var targetEntity))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                return false;
            }

            if (!targetEntity.TryGetGameObjectComponent<BoxCollider>(out var box))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(box), (nameof(entity), entity), (nameof(targetEntity), targetEntity));
                return false;
            }

            result = box.size;
            return true;
        }
    }
}