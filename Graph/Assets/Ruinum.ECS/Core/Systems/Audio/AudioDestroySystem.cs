using Entitas;

namespace Ruinum.ECS.Systems.Audio
{
    public sealed class AudioDestroySystem : GroupExecuteSystem<GameEntity>
    {
        public AudioDestroySystem(IContext<GameEntity> context) : base(context, GameMatcher.PlayableAudio) { }

        protected override void Execute(GameEntity entity)
        {
            if (!entity.playableAudio.Source.loop || entity.playableAudio.Source.isPlaying) return;

            entity.RemovePlayableAudio();
            UnityEngine.Object.Destroy(entity.playableAudio.Source);

            if (entity.hasAudioOnDestroy)
            {
                entity.audioOnDestroy.Strategy.Process(entity);
                entity.RemoveAudioOnDestroy();
            }
        }
    }
}