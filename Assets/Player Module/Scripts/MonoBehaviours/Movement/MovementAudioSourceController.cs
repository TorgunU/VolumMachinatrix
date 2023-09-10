using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovementAudioSourceController : MonoBehaviour
{
    [SerializeField] private AudioSource _walkingSource;
    [SerializeField] private AudioSource _movingSource;
    [SerializeField] private AudioSource _runningSource;

    private AudioSource _currentPlayingSource;
    private float _defaultVolumeValue;

    private void Start()
    {
        _defaultVolumeValue = _movingSource.volume;
    }

    public void PlayWalking()
    {
        Play(_walkingSource);
    }

    public void PlayMoving()
    {
        Play(_movingSource);
    }

    public void PlayRunning()
    {
        Play(_runningSource);
    }

    private void Play(AudioSource audioSource)
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        else if(audioSource == _currentPlayingSource)
        {
            return;
        }
        else
        {
            StartCoroutine(ReducingVolume(audioSource));
        }

        audioSource.Play();
    }

    private IEnumerator ReducingVolume(AudioSource audioSource)
    {
        yield return new WaitWhile(() =>
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, _defaultVolumeValue, 5 * Time.deltaTime);

            return audioSource.volume == 0;
        });

        audioSource.Stop();
        audioSource.volume = _defaultVolumeValue;
    }
}