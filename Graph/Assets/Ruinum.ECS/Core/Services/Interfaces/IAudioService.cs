namespace Ruinum.ECS.Services.Interfaces
{
    public interface IAudioService
    {
        void PlayAudio(GameEntity entity, AudioConfigComponent audio, AudioTargetComponent audioTarget);
    }
}