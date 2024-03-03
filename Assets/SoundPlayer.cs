using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public static SoundPlayer instance;

    private AudioSource source;

    [Range(0.0f, 1.0f)]
    public float maxVolume = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx, float volumeMultiplier = 1.0f)
    {
        source?.PlayOneShot(sfx, volumeMultiplier);
    }

    public void SetMusic(AudioClip newMusic, float transitionTime = 1.0f)
    {
        StartCoroutine(MusicTransitionRoutine(newMusic, transitionTime));
    }

    IEnumerator MusicTransitionRoutine(AudioClip newMusic, float transitionTime)
    {
        if (source == null)
        {
            yield break;
        }
        
        float remainingTime = transitionTime;
        while (remainingTime > 0.0f)
        {
            remainingTime -= Time.deltaTime;
            source.volume = maxVolume * (remainingTime / transitionTime);
            yield return null;
        }
        
        source.Stop();
        source.clip = newMusic;
        source.Play();
        
        remainingTime = transitionTime;
        while (remainingTime > 0.0f)
        {
            remainingTime -= Time.deltaTime;
            source.volume = maxVolume * (1.0f - (remainingTime / transitionTime));
            yield return null;
        }
    }
}
