using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class HalfExtendsVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;
        private static readonly Vector3 HalfExtendsVector = Vector3.one / 2;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                result = default;
                if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
                return false;
            }

            result = Vector3.Scale(vector, HalfExtendsVector);
            return true;
        }
    }
}