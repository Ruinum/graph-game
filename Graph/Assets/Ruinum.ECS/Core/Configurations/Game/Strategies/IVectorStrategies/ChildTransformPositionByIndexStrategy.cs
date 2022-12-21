using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ChildTransformPositionByIndexStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Parent;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Index;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Parent.TryGet(entity, out var target))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.TryGetTransform(out var transform))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(transform), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (!Index.TryGet(entity, out var index))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(index), (nameof(entity), entity), (nameof(target), target), (nameof(transform), transform));
                return false;
            }

            if (index < 0 || index >= transform.childCount)
            {
                result = default;
                if(Logging) LogError($"Index out of range.", (nameof(entity), entity), (nameof(target), target), (nameof(transform), transform), (nameof(index), index));
                return false;
            }

            result = transform.GetChild((int) index).position;
            return true;
        }
    }
}