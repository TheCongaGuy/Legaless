using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool Loop;
    public bool Random_pitch;
    [Range(0.5f, 1.5f)]
    public float Random_Pitch_High;
    [Range(0.5f, 1.5f)]
    public float Random_Pitch_Low;

    [HideInInspector]
    public AudioSource source;
}
