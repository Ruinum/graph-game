using Ruinum.ECS.Core.Systems.Log;
using UnityEngine;

namespace Ruinum.ECS.Services.Interfaces
{
    public sealed class AudioService : IAudioService
    {
        public bool TryPlayAudio(GameEntity entity, AudioConfigComponent audio, AudioTargetComponent audioTarget, out AudioSource audioSource)
        {
            audioSource = default;

            if (!audioTarget.Target.TryGet(entity, out var target)) 
            {
                LogExtention.Error($"Can't find target. {audio.Config.Clip}, {entity}");
                return false;
            }

            if (target.hasGameObject)
            {
                return TryPlayAudioOnObject(entity, audio, audioTarget, out audioSource);                
            }

            AudioConfig config = audio.Config;
            audioSource = CreateAudioSource(config);
            audioSource.Play();

            return true; 
        }

        private bool TryPlayAudioOnObject(GameEntity target,  AudioConfigComponent audio, AudioTargetComponent audioTarget, out AudioSource audioSource)
        {
            audioSource = default;
            
            if (!target.hasTransformPosition)
            {
                LogExtention.Error($"Can't take {nameof(TransformPositionComponent)} from {target}, {audio.Config.Clip}, {target}");
                return false;
            }

            AudioConfig config = audio.Config;
            audioSource = CreateAudioSource(config);
            audioSource.transform.position = target.transformPosition.Value;
            audioSource.transform.parent = target.gameObject.Value.transform;
            audioSource.Play();
            
            if (!config.Loop) Object.Destroy(audioSource, config.Clip.length);
            
            return true;
        }

        private AudioSource CreateAudioSource(AudioConfig config)
        {
            AudioSource audioSource =  new GameObject(config.Clip.ToString(), typeof(AudioSource)).GetComponent<AudioSource>();
            
            audioSource.clip = config.Clip;
            audioSource.loop = config.Loop;
            audioSource.pitch = config.Pitch;
            audioSource.panStereo = config.StereoPan;
            audioSource.spatialBlend = config.SpatialBlend;
            audioSource.reverbZoneMix = config.ReverbZoneMix;

            return audioSource;
        }
    }
}