using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class ColliderHitNormalStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public bool Inverse;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            result = default;
            if (!entity.hasColliderHit)
            {
                result = default;
                if(Logging) LogErrorNotFound("ColliderHitComponent", (nameof(entity), entity));
                return false;
            }

            //result = (Inverse ? -1 : 1) * entity.colliderHit.Value.Normal;
            return true;
        }
    }
}