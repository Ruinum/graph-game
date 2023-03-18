using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using UnityEngine;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class ColorStrategy : IColorStrategy
    {
        public ITargetStrategy Target;
        public bool TryGet(GameEntity entity, out Color result)
        {
            result = default;
            if (!Target.TryGet(entity, out var target))
            {
                return false;
            }
            if (!target.hasColor)
            {
                return false;
            }
            result = target.color.Color;
            return true;
        }

    }
}
