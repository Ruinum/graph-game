using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class PlayAudioEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public IAudioConfigStrategy Strategy;
        
        public override bool Process(GameEntity entity)
        {
            if (!Strategy.TryGet(entity, out var config))
            {
                if (Logging) LogError($"{nameof(PlayAudioEntityStrategy)}, {Strategy}, {entity}");
                return false;
            }

            entity.ReplaceAudioTarget(Target);
            entity.ReplaceAudioConfig(config);

            return true;
        }
    }
}
