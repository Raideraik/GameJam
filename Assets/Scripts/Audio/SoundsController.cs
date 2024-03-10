using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public static SoundsController Instance { get; private set; }
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip) 
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
