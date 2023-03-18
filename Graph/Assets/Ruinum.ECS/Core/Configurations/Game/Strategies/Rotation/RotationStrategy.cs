using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Rotation
{
    public abstract class RotationStrategy : ContextInitializable
    {
        public abstract bool TryGet(GameEntity entity, out Quaternion rotation);
    }
}