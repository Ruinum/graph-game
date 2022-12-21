using Ruinum.ECS.Extensions;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class TransformMoveVectorStrategy : VectorStrategy
    {
        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            var root = entity.GetRootOwnerOrThis();
            if (!root.hasTransformMoveVector)
            {
                result = default;
                if(Logging) LogErrorNotFound("RootOwner TransformMoveVectorComponent", (nameof(entity), entity));
                return false;
            }

            result = root.transformMoveVector.Value;
            return true;
        }
    }
}