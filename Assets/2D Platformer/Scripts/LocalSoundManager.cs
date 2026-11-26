using UnityEngine;
using DG.Tweening;

public class LocalSoundManager : MonoBehaviour
{
    public Sound[] soundList;

    void Awake()
    {
        for(int i = 0; i < soundList.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            soundList[i].SetAudioSource(audioSource);
        }
    }

    public Sound FindSound(string name)
    {
        for (int i = 0; i < soundList.Length; i++)
        {
            if (soundList[i].soundName == name)
            {
                return soundList[i];
            }
        }

        Debug.LogWarning($"Sonido con nombre {name} no existe en la lista");
        return null;

    }

    public void PlaySound(string name)
    {
        Sound sound = FindSound(name);

        if(sound != null)
        {
            sound.source.Play();
        }
    }

    public void PauseSound(string name)
    {
        Sound sound = FindSound(name);

        if (sound != null)
        {
            sound.source.Pause();
        }
    }

    public void StopSound(string name)
    {
        Sound sound = FindSound(name);

        if (sound != null)
        {
            sound.source.Stop();
        }
    }

    public void FadeInSound(string name, float fadeTime = 1, float delay = 2)
    {
        Sound sound = FindSound(name);

        if (sound != null)
        {
            sound.source.volume = 0;
            sound.source.Play();

            //SetUpdate(true) = indica que el tween esta usando realtime y no runtime
            //SetDelay = indica cuántos segundos se esperará el tween para ejecutarse.
            sound.source.DOFade(sound.volume, fadeTime)
                .SetDelay(delay);
        }
    }

    public void FadeOutSound(string name, float fadeTime = 1, float delay = 2)
    {
        Sound sound = FindSound(name);

        if (sound != null)
        {
            sound.source.DOFade(0, fadeTime)
                .SetDelay(delay)
                .OnComplete(()=>StopSound(sound.soundName));
        }
    }

    public void PlayWithRandomPitch(string name, float pitchMin = 0.9f, float pitchMax = 1.2f)
    {
        Sound sound = FindSound(name);
        float pitch = Random.Range(pitchMin, pitchMax);

        //Si el pitch es zero no se oye, usar el valor del pitch del sonido
        if(pitch == 0)
        {
            pitch = sound.pitch;
        }

        if(sound != null)
        {
            sound.source.pitch = pitch;//setear el pitch del audioSource del sonido al pitch random
            sound.source.Play();
        }
    }

    public void PlayRandomSound(bool useRandomPitch = false, float pitchMin = 0.9f, float pitchMax = 1.2f)
    {
        int randomIndex = Random.Range(0, soundList.Length);

        Sound sound = soundList[randomIndex];

        if (sound != null)
        {
            if (useRandomPitch)
            {
                PlayWithRandomPitch(sound.soundName, pitchMin, pitchMax);
                return;
            }

            sound.source.Play();
        }
    }

}
