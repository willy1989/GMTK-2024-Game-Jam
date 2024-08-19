using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySoundEffect()
    {
        audioSource.Play();
    }
}
