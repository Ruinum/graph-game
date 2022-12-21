using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using UnityEngine;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SpriteStrategy : ISpriteStrategy
    {
        public ITargetStrategy Target;
        public bool TryGet(GameEntity entity, out Sprite result)
        {
            result = default;
            if(!Target.TryGet(entity, out var target)) { return false; }
            if (!target.hasSprite) { return false; }
            result = entity.sprite.Value;
            return true;
        }
    }
}