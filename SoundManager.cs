using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    static SoundManager instance;

    public bool Freed = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }
    }

    private void Start()
    {
        Play("Music");
    }

    public void PitchRandom(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.pitch = UnityEngine.Random.Range(s.Random_Pitch_Low, s.Random_Pitch_High);
        }
    }

    public void AdjustVolume(string name, float Volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.volume = Volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void FreeHim()
	{
        Freed = true;
	}
}
