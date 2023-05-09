using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = EditorConstants.RootMenuConfigPath + nameof(AudioConfig), fileName = nameof(AudioConfig))]
public sealed class AudioConfig : SerializedScriptableObject
{
    public AudioClip Clip;
    public bool Loop;

    [Range(0f, 256f)]
    public float Priority = 128f;
    [Range(0f,1f)]
    public float Volume = 1f;
    [Range(-3f, 3f)]
    public float Pitch = 1f;
    [Range(-1f, 1f)]
    public float StereoPan = 0f;
    [Range(0f, 1f)]
    public float SpatialBlend = 0f;
    [Range(0f, 1.1f)]
    public float ReverbZoneMix = 1f;
}