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
    private ITorsoRotaionLimiter _torsoRotaionLimiter;
    private Vector2 _direction;
    private Vector2 _move;


    private void Awake()
    {
        _playerInput = GetComponent<KeyboardMouseInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _torsoRotaionLimiter = GetComponentInChildren<ITorsoRotaionLimiter>();
    }

    private void Start()
    {
        _movingSpeed = 7;
        _runningSpeed = 25;
        _walkingSpeed = 2;
        _rigidbody2D.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        SetDirection();
        Move();
    }

    public float Speed { get => _movingSpeed; private set => _movingSpeed = value; }

    private void SetDirection()
    {
        _direction = _playerInput.GetMovementDirection();
        _torsoRotaionLimiter.CheckTorsoAngleLimit(_direction);
    }

    private void Move()
    {
        var newDirection = new Vector2(_direction.x, _direction.y);

        _move = newDirection;

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

        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * scaledMoveSpeed);
    }
}