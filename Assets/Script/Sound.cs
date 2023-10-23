using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.3f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public bool playOnAwake;

    [Range(0f, 10f)]
    public int priority;
}
