using System;
using UnityEngine;

[Serializable]
public class PlayerRangeAiming : IAimable, IDisposable
{
    [SerializeField] private float _currentSummaryModifier;
    [SerializeField] private float _movementModifier;
    [SerializeField] private float _movingDebuff = -0.3f;
    [SerializeField] private float _walkingDebuff = -0.1f;
    [SerializeField] private float _runningDebuff = -0.5f;
    [SerializeField] private float _stayingBuff = 0.2f;

    private IAimingEvents _aimingInput;
    private Crosshair _crosshair;
    private RangeWeaponConfig _rangeWeaponConfig;
    private PlayerSpeed _playerSpeed;
    private bool _disposed = false;

    public PlayerRangeAiming(Crosshair crosshair, IAimingEvents aimingInput,
        PlayerSpeed playerSpeed, RangeWeaponConfig rangeWeaponConfig)
    {
        _crosshair = crosshair;
        _aimingInput = aimingInput;
        _playerSpeed = playerSpeed;

        _aimingInput.AimHolded += ChangeAimState;
        _playerSpeed.SpeedChanged += OnSpeedChanged;

        _movementModifier = _stayingBuff;

        InjectRangeWeaponConfig(rangeWeaponConfig);
    }


    public void InjectRangeWeaponConfig(RangeWeaponConfig rangeWeaponConfig)
    {
        _rangeWeaponConfig = rangeWeaponConfig;
    }

    public void OnSpeedChanged(float speed)
    {
        if (Mathf.Approximately(0, speed))
        {
            _movementModifier = _stayingBuff;
        }
        else if (speed < _playerSpeed.WalkingSpeed)
        {
            _movementModifier = _walkingDebuff;
        }
        else if (speed < _playerSpeed.MovingSpeed)
        {
            _movementModifier = _movingDebuff;
        }
        else if (speed < _playerSpeed.RunningSpeed)
        {
            _movementModifier = _runningDebuff;
        }

        CalculateAimModifier();
    }

    public void ChangeAimState(bool isAiming)
    {
        if(isAiming)
        {
            Aim();
        }
        else if(isAiming == false)
        {
            StopAim();
        }
    }

    public void Aim()
    {
        CalculateAimModifier();
    }

    public void StopAim()
    {
        _crosshair.AimModifier = 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void CalculateAimModifier()
    {
        _crosshair.AimModifier = _movementModifier + _rangeWeaponConfig.AimModifier;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed == false)
        {
            if (disposing)
            {
                 _aimingInput.AimHolded -= ChangeAimState;
                _playerSpeed.SpeedChanged -= OnSpeedChanged;
            }

            _disposed = true;
        }
    }

    ~PlayerRangeAiming()
    {
        Dispose(false);
    }
}