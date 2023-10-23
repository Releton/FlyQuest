using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.priority = s.priority;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(name))
            {
                sounds[i].source.Play();
                break;
            }
        }
    }

    public void Pause(string name)
    {
        for (int i = 0; i < sounds.Length; i++) {
            if (sounds[i].name.Equals(name)) {
                sounds[i].source.Pause();
                break;
            }
        }
    }

    public void PauseAllExcept(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(name))
            {
                continue;
            }
            sounds[i].source.Pause();
        }
    }

}
