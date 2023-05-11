using UnityEngine;

namespace Ruinum.ECS.Services.Interfaces
{
    public interface IAudioService
    {
        bool TryPlayAudio(GameEntity entity, AudioConfigComponent audio, AudioTargetComponent audioTarget, out AudioSource audioSource);
    }
}