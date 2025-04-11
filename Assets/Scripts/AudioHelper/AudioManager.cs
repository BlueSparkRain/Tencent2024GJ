using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoSingleton<AudioManager>
{

    public IEnumerator PlayAudio(AudioClip clip, float track)
    {
        AudioSource audioSource = new AudioSource();

        this.gameObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.panStereo = Mathf.Clamp(track,-1,1);

        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource);
    }

    public void PlayAudio(AudioClip clip)
    {
        PlayAudio(clip, 0);
    }
}
