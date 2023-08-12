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

        float legsAngle = _legsRotaionLimiter.GetLegsRoationAngle();
      
        Vector2 legsDirection = new Vector2(Mathf.Cos(legsAngle * Mathf.Deg2Rad), Mathf.Cos(legsAngle * Mathf.Deg2Rad)).normalized;
        Vector2 moveDirection = Vector2.Scale(legsDirection, _inputDirection.normalized);

        Debug.Log(moveDirection);
        Debug.DrawRay(transform.position, legsDirection, Color.black);
        Debug.DrawRay(transform.position, moveDirection, Color.green);

        _rigidbody2D.MovePosition(_rigidbody2D.position + moveDirection * scaledMoveSpeed);
    }
}