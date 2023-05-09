using UnityEngine;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SimpleColorStrategy : IColorStrategy
    {
        public Color Color;
        public bool TryGet(GameEntity entity, out Color result)
        {
            result = Color;
            return true;
        }
    }
}
