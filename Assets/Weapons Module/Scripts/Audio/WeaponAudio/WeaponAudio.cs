using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class WeaponAudio : MonoBehaviour
{
    [SerializeField] protected WeaponAudioConfig WeaponAudioConfig;
    // weapon reloading audio, etc

    public abstract void PlayAttack();
}