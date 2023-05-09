using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class AudioConfigStrategy : IAudioConfigStrategy
    {
        public ITargetStrategy Target;
        
        public bool TryGet(GameEntity entity, out AudioConfig result)
        {
            result = default;

            if (!Target.TryGet(entity, out var target))
            {
                return false;
            }
            if (!target.hasAudioConfig)
            {
                return false;
            }

            result = target.audioConfig.Config;
            return true;
        }
    }
}
