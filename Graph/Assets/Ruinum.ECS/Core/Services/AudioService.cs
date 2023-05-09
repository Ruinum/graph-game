using Ruinum.ECS.Core.Systems.Log;
using UnityEngine;

namespace Ruinum.ECS.Services.Interfaces
{
    public sealed class AudioService : IAudioService
    {
        public void PlayAudio(GameEntity entity, AudioConfigComponent audio, AudioTargetComponent audioTarget)
        {
            if (!audioTarget.Target.TryGet(entity, out var target)) 
            {
                LogExtention.Error($"Can't find target. {audio.Config.Clip}, {entity}");
                return;
            }

            if (target.hasGameObject)
            {
                PlayAudioOnObject(entity, audio, audioTarget);
                return;
            }

            AudioConfig config = audio.Config;
            AudioSource audioSource = CreateAudioSource(config);
            audioSource.Play();

            if (!config.Loop) Object.Destroy(audioSource, config.Clip.length);
        }

        private void PlayAudioOnObject(GameEntity target,  AudioConfigComponent audio, AudioTargetComponent audioTarget)
        {
            if (!target.hasTransformPosition)
            {
                LogExtention.Error($"Can't take {nameof(TransformPositionComponent)} from {target}, {audio.Config.Clip}, {target}");
                return;
            }

            AudioConfig config = audio.Config;
            AudioSource audioSource = CreateAudioSource(config);
            audioSource.transform.position = target.transformPosition.Value;
            audioSource.transform.parent = target.gameObject.Value.transform;
            audioSource.Play();
            
            if (!config.Loop) Object.Destroy(audioSource, config.Clip.length);
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