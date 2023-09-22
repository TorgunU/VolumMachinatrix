using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RangeAttackAudio : WeaponAttackAudio
{
    protected IEnumerator WaitingEndClip()
    {
        float currentPlayingTime;

        yield return new WaitWhile(() =>
        {
            currentPlayingTime = Time.deltaTime;
            return AudioSource.isPlaying || currentPlayingTime >= MaxPlayingTime;
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