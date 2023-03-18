using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class NormalizeVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
                return false;
            }

            result = vector.normalized;
            return true;
        }
    }
}