using UnityEngine;

[System.Serializable] //anotación que hace que clases "puras" sean visibles en el inspector
public class Sound
{
    public string soundName;
    public AudioClip audioClip;

    [Range(0, 1)]
    public float volume = 1;

    [Range (-3, 3)]
    public float pitch = 1;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;

    public void SetAudioSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = audioClip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.playOnAwake = playOnAwake;

        if (playOnAwake)
        {
            source.Play();
        }
    }
}
