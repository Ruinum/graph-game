using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class AudioVolumeEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public IFloatValueStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if (Logging) LogErrorNotFound($"{Target}, {entity}");
                return false;
            }

            if (!target.hasPlayableAudio)
            {
                if (Logging) LogErrorNotFound($"{nameof(PlayableAudioComponent)}, {target}, {entity}");
                return false;
            }

            if (!Strategy.TryGet(entity, out var value))
            {
                if (Logging) LogErrorNotFound($"{Strategy}, {entity}");
                return false;
            }

            target.playableAudio.Source.volume = value;
            return true;
        }
    }
}
