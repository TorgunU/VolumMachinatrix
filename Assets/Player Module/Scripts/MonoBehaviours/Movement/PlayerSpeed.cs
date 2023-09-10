using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;

    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _targetSpeed;
    [SerializeField] private float _speedChangeRate;

    [SerializeField] private float _startInertia;
    [SerializeField] private float _movingIntertia;
    [SerializeField] private float _runningIntertia;
    [SerializeField] private float _walkingIntertia;

    private const float MaxSpeed = 50;

    private void Awake()
    {
        _movingSpeed = 15f;
        _runningSpeed = 20f;
        _walkingSpeed = 7f;

        _currentSpeed = 0f;
        _targetSpeed = 0f;
        _speedChangeRate = 0.5f;

        _startInertia = 0f;
        _movingIntertia = 0.5f;
        _runningIntertia = 0.7f;
        _walkingIntertia = 0.2f;
    }

    public void StartMoving()
    {
        TargetSpeed = _movingSpeed;
        _startInertia = _movingIntertia;
    }

    public void SetRunState(bool isRunning)
    {
        _startInertia = _runningIntertia;
        TargetSpeed = isRunning ? _runningSpeed : _movingSpeed;
    }

    public void SetWalkState(bool isWalking)
    {
        _startInertia = _walkingIntertia;

        TargetSpeed = isWalking ? _walkingSpeed : _movingSpeed;
    }

    public void ResetSpeeding()
    {
        CurrentSpeed = 0;
        _targetSpeed = 0;
        _startInertia = 0;
    }

    private IEnumerator TowardsSpeed()
    {
        while (Mathf.Approximately(CurrentSpeed, TargetSpeed) == false)
        {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, _targetSpeed, Time.deltaTime * (_speedChangeRate + _startInertia));

            yield return null;
        }

        _targetSpeed = 0;
        _startInertia = 0;
    }

    public float CurrentSpeed
    {
        get => _currentSpeed;

        private set
        {
            if (value >= MaxSpeed)
            {
                value = MaxSpeed;
            }

            _currentSpeed = value;

            SpeedChanged?.Invoke(_currentSpeed);
        }
    }

    public float TargetSpeed
    {
        get => _targetSpeed;

        private set
        {
            _targetSpeed = value;
            StartCoroutine(TowardsSpeed());
        }
    }

    public float MovingSpeed { get => _movingSpeed; }
    public float WalkingSpeed { get => _walkingSpeed; }
    public float RunningSpeed { get => _runningSpeed; }

    public Action<float> SpeedChanged;
}