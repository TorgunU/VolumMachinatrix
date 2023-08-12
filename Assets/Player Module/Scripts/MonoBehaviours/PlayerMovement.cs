using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private ILegRotaionLimiter _legsRotaionLimiter;
    private Vector2 _inputDirection;

    public float Speed { get => _movingSpeed; private set => _movingSpeed = value; }

    private void Awake()
    {
        _playerInput = GetComponent<KeyboardMouseInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _legsRotaionLimiter = GetComponentInChildren<ILegRotaionLimiter>();
    }

    private void Start()
    {
        _movingSpeed = 7;
        _runningSpeed = 25;
        _walkingSpeed = 2;
        _rigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        SetDirection();
        RotateLegs();
        Move();
    }

    private void SetDirection()
    {
        _inputDirection = _playerInput.GetMovementDirection();
    }

    private void RotateLegs()
    {
        _legsRotaionLimiter.Rotate(_inputDirection);
    }

    private void Move()
    {
        float scaledMoveSpeed;

        if(_playerInput.IsChangeOnRun())
        {
            scaledMoveSpeed = _runningSpeed * Time.fixedDeltaTime;
        }
        else if(_playerInput.IsChangedOnWalk())
        {
            scaledMoveSpeed = _walkingSpeed * Time.fixedDeltaTime;
        }
        else
        {
            scaledMoveSpeed = _movingSpeed * Time.fixedDeltaTime;
        }

        _rigidbody2D.MovePosition(_rigidbody2D.position + _inputDirection.normalized * scaledMoveSpeed);
    }
}