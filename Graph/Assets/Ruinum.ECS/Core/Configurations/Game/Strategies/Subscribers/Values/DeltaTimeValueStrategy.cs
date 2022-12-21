using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class DeltaTimeValueStrategy : FloatValueBaseStrategy
    {
        public override bool TryGet(GameEntity entity, out float value)
        {
            value = Time.deltaTime;
            return true;
        }
    }
}