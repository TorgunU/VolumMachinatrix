using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RangeAttackAudio : WeaponAttackAudio
{
    protected IEnumerator WaitingEndClip()
    {

        yield return new WaitWhile(() =>
        {
            return AudioSource.isPlaying;
        });

        FinishedPlaying?.Invoke(this);
    }

    public override void Play()
    {
        AudioSource.Play();

        StartCoroutine(WaitingEndClip());
    }

    public event Action<RangeAttackAudio> FinishedPlaying;
}