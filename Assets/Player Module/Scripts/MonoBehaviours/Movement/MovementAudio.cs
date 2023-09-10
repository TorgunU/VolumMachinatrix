using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _walkingSource;
    [SerializeField] private AudioSource _movingSource;
    [SerializeField] private AudioSource _runningSource;

    private AudioSource _stayingSource;

    private AudioSource _currentPlayingSource;
    private float _defaultVolumeValue;

    private void Start()
    {
        _defaultVolumeValue = 1;

        _currentPlayingSource = _movingSource;
    }

    public void StopPlaying()
    {
        if (_currentPlayingSource == null)
            return;

        _currentPlayingSource.Stop();
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

        _currentPlayingSource.Stop();

        _currentPlayingSource = audioSource;

        _currentPlayingSource.Play();
    }

    //private IEnumerator ReducingVolume(AudioSource audioSource)
    //{
    //    yield return new WaitWhile(() =>
    //    {
    //        audioSource.volume = Mathf.Lerp(audioSource.volume, 0, 0.3f * Time.deltaTime);

    //        return audioSource.volume == 0;
    //    });

    //    audioSource.Stop();
    //    audioSource.volume = _defaultVolumeValue;
    //}
}