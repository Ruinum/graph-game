using System.Collections.Generic;
using Entitas;
using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Systems.Audio
{
    public sealed class AudioPlaySystem : ReactiveSystem<GameEntity>
    {
        private readonly IAudioService _audioService;

        public AudioPlaySystem(IContext<GameEntity> context, IAudioService audioService) : base(context)
        {
            _audioService = audioService;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                if (_audioService.TryPlayAudio(entity, entity.audioConfig, entity.audioTarget, out var audioSource))
                {
                    entity.ReplacePlayableAudio(audioSource);                    
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAudioTarget && entity.hasAudioConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AudioTarget);
        }
    }
}