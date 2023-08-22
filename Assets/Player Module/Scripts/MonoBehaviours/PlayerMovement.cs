using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;

    private IMovementEvents _inputEvents;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;
    private bool _isRunning;
    private bool _isWalking;

    public float Speed { get => _movingSpeed; private set => _movingSpeed = value; }

    public void Init(Rigidbody2D rigidbody2D, IMovementEvents playerInputEvents)
    {
        _rigidbody2D = rigidbody2D;
        _inputEvents = playerInputEvents;

        _rigidbody2D.gravityScale = 0;
    }


    private void Start()
    {
        _movingSpeed = 7;
        _runningSpeed = 25;
        _walkingSpeed = 2;

        _inputEvents.MovementDirectionUpdated += SetMoveDirection;
        _inputEvents.WalkStateChanged += SetWalkState;
        _inputEvents.RunStateChanged += SetRunState;
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _inputEvents.MovementDirectionUpdated -= SetMoveDirection;
        _inputEvents.WalkStateChanged -= SetWalkState;
        _inputEvents.RunStateChanged -= SetRunState;
    }

    public void Move()
    {
        float scaledMoveSpeed;

        if(_isRunning)
        {
            scaledMoveSpeed = _runningSpeed * Time.fixedDeltaTime;
        }
        else if(_isWalking)
        {
            scaledMoveSpeed = _walkingSpeed * Time.fixedDeltaTime;
        }
        else
        {
            scaledMoveSpeed = _movingSpeed * Time.fixedDeltaTime;
        }

        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * scaledMoveSpeed);

        Debug.DrawRay(transform.position, _moveDirection, Color.white);
    }

    private void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void SetRunState(bool isRunning)
    {
        _isRunning = isRunning;
    }

    private void SetWalkState(bool isWalking)
    {
        _isWalking = isWalking;
    }
}