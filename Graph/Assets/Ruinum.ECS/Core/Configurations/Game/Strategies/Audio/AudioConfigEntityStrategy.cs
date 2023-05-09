using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class AudioConfigEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public IAudioConfigStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                return false;
            }
            
            if (!Strategy.TryGet(entity, out var audioConfig))
            {
                return false;
            }

            target.ReplaceAudioConfig(audioConfig);
            return true;
        }
    }
}
