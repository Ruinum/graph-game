using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public abstract class VectorStrategy : ContextInitializable, IVectorStrategy
    {
        public abstract bool TryGet(GameEntity entity, out Vector3 result);
    }
}