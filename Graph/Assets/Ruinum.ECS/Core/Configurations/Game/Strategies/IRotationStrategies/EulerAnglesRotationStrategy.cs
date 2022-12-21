using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public sealed class EulerAnglesRotationStrategy : RotationStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Vector = new SimpleVectorStrategy();

        public override bool TryGet(GameEntity entity, out Quaternion rotation)
        {
            if (!Vector.TryGet(entity, out var vector))
            {
                rotation = default;
                if(Logging) LogErrorNotFound("Vector", (nameof(entity), entity));
                return false;
            }

            rotation = Quaternion.Euler(vector);
            return true;
        }
    }
}