using System.Collections.Generic;
using Entitas;
using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Systems.Audio
{
    public sealed class AudioSystem : ReactiveSystem<GameEntity>
    {
        private readonly IAudioService _audioService;

        public AudioSystem(IContext<GameEntity> context, IAudioService audioService) : base(context)
        {
            _audioService = audioService;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                _audioService.PlayAudio(entity, entity.audioConfig, entity.audioTarget);
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