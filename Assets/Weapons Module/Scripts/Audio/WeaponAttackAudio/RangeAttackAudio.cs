using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RangeAttackAudio : WeaponAttackAudio
{
    protected Coroutine WaitingEndClipCoroutine;

    private void OnDisable()
    {
        if(WaitingEndClipCoroutine != null)
        {
            StopCoroutine(WaitingEndClipCoroutine);
            FinishedPlaying?.Invoke(this);
        }
    }

    protected IEnumerator WaitingEndClip()
    {
        float currentPlayingTime = 0f;

        yield return new WaitWhile(() =>
        {
            currentPlayingTime += Time.deltaTime;
            return AudioSource.isPlaying || currentPlayingTime >= MaxPlayingTime;
        });

        FinishedPlaying?.Invoke(this);
    }

    public override void Play()
    {
        AudioSource.Play();

        WaitingEndClipCoroutine = StartCoroutine(WaitingEndClip());
    }

    public event Action<RangeAttackAudio> FinishedPlaying;
}