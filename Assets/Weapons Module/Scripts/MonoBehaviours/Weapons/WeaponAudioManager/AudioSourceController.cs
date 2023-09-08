using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioSourceController : MonoBehaviour
{
    [SerializeField] protected AudioSource _attackAudioSource;

    public abstract void PlayAudioClip();

    public abstract event Action<AudioSourceController> FinishedPlaying;
}
