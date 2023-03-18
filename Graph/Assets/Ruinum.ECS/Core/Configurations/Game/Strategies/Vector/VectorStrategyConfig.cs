using Ruinum.ECS.Constants;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    [CreateAssetMenu(menuName = EditorConstants.EntityStrategyMenuPath + nameof(VectorStrategyConfig), fileName = nameof(VectorStrategyConfig))]
    public sealed class VectorStrategyConfig : InitializableSerializedConfig, IVectorStrategy
    {
        public IVectorStrategy Vector;

        public bool TryGet(GameEntity entity, out Vector3 result)
        {
            return Vector.TryGet(entity, out result);
        }
    }
}