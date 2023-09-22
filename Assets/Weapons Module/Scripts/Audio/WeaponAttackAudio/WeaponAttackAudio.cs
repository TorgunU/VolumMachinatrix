using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAttackAudio : MonoBehaviour, IAudioPlayable
{
    [SerializeField] protected AudioSource AudioSource;

    protected float MaxPlayingTime;

    public virtual void Awake()
    {
        MaxPlayingTime = AudioSource.clip.frequency + 1f;
    }

    public abstract void Play();


    public void Init(AudioSource audioSource)
    {
        AudioSource.clip = audioSource.clip;
    }
}