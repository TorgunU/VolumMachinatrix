using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private ITorsoRotaionLimiter _torsoRotaionLimiter;
    private Vector2 _direction;
    private Vector2 _previousDirection;
    private Vector2 _move;


    private void Awake()
    {
        _playerInput = GetComponent<KeyboardMouseInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _torsoRotaionLimiter = GetComponentInChildren<ITorsoRotaionLimiter>();
    }

    private void Start()
    {
        _speed = 7;
        _rigidbody2D.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        SetDirection();
        Move();
    }

    public float Speed { get => _speed; private set => _speed = value; }

    private void SetDirection()
    {
        _direction = _playerInput.GetMovementDirection();
        _torsoRotaionLimiter.CheckTorsoAngleLimit(_direction);

        //if(_direction != _previousDirection)
        //{
        //    _previousDirection = _direction;
        //    _torsoRotaionLimiter.CheckTorsoAngleLimit(_direction);
        //}
    }

    private void Move()
    {
        var newDirection = new Vector2(_direction.x, _direction.y);

        _move = newDirection;

        float scaledMoveSpeed = _speed * Time.fixedDeltaTime;

        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * scaledMoveSpeed);
    }
}