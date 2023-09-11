using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAttackAudio : MonoBehaviour, IAudioPlayable
{
    [SerializeField] protected AudioSource AudioSource;

    public abstract void Play();
}