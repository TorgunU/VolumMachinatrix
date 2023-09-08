using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RangeAttackAudioController : AudioSourceController
{
    protected IEnumerator WaitingEndAudioClip()
    {

        yield return new WaitWhile(() =>
        {
            return _attackAudioSource.isPlaying;
        });

        FinishedPlaying.Invoke(this);
    }

    public override void PlayAudioClip()
    {
        _attackAudioSource.Play();

        StartCoroutine(WaitingEndAudioClip());
    }

    public override event Action<AudioSourceController> FinishedPlaying;
}