using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instace;

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    private void Awake()
    {
        Instace = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ������Ƶ
    /// </summary>
    /// <param name="audioClip"></param>
    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
