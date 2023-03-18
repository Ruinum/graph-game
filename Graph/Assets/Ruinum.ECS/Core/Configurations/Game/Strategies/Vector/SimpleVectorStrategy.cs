using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class SimpleVectorStrategy : VectorStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3 Vector;

        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            result = Vector;
            return true;
        }
    }
}