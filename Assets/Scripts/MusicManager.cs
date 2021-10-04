using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager s_Instance;
    public static MusicManager Instance => s_Instance;

    public AudioSource BgmAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip happinessStateClip;
    public AudioClip cleaningStateStartClip;
    public AudioClip cleaningStateClip;
    public AudioClip brake;
    public AudioClip clean;

    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(this);
            return;
        }

        s_Instance = this;
    }


    public void PlayHappinessStateClip()
    {
        BgmAudioSource.clip = happinessStateClip;
        BgmAudioSource.Play();
    }

    public IEnumerator PlayCleaningStateClip()
    {
        BgmAudioSource.volume = 0.8f;
        BgmAudioSource.clip = cleaningStateStartClip;
        BgmAudioSource.Play();

        yield return new WaitForSeconds(cleaningStateStartClip.length);

        BgmAudioSource.volume = 0.25f;
        BgmAudioSource.clip = cleaningStateClip;
        BgmAudioSource.Play();
        UI_CleanBar.Instance.SetActive(true);
    }

    public void PlayBrake()
    {
        sfxAudioSource.PlayOneShot(brake);
    }    
    
    public void PlayClean()
    {
        sfxAudioSource.PlayOneShot(clean);
    }

    public void PlayClip(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }
}
