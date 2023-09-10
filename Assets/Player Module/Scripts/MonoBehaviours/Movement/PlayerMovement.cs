using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent (typeof(PlayerSpeed))]
public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private MovementAudioSourceController MovementAudioSourceController;

    private IMovementDirection _inputEvents;
    private IMovementStateEvents _movementStateEvents;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;
    private PlayerSpeed _playerSpeed;

    public void Init(Rigidbody2D rigidbody2D, IMovementDirection playerInputEvents, 
        IMovementStateEvents movementStateEvents)
    {
        _rigidbody2D = rigidbody2D;
        _inputEvents = playerInputEvents;
        _movementStateEvents = movementStateEvents;

        _rigidbody2D.gravityScale = 0;

        _inputEvents.MovementDirectionUpdated += SetDirection;
        _movementStateEvents.WalkStateChanged += _playerSpeed.SetWalkState;
        _movementStateEvents.RunStateChanged += _playerSpeed.SetRunState;
    }

    private void Awake()
    {
        _playerSpeed = GetComponent<PlayerSpeed>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _playerSpeed.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        _inputEvents.MovementDirectionUpdated -= SetDirection;

        _movementStateEvents.WalkStateChanged -= _playerSpeed.SetWalkState;
        _movementStateEvents.RunStateChanged -= _playerSpeed.SetRunState;

        _playerSpeed.SpeedChanged -= OnSpeedChanged;
    }

    public void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * _playerSpeed.CurrentSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, _moveDirection, Color.white, 1);
    }

    public void SetDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;

        if (_moveDirection == Vector2.zero)
        {
            _playerSpeed.ResetSpeeding();
        }
        else
        {
            _playerSpeed.StartMoving();
        }
    }

    private void OnSpeedChanged(float speed)
    {
        PlayMovementAudio(speed);
    }

    private void PlayMovementAudio(float speed)
    {
        if (Mathf.Approximately(0, speed))
        {
            return;
        }
        else if (speed <= _playerSpeed.WalkingSpeed)
        {
            MovementAudioSourceController.PlayWalking();
        }
        else if (speed <= _playerSpeed.MovingSpeed)
        {
            MovementAudioSourceController.PlayMoving();
        }
        else if (speed <= _playerSpeed.RunningSpeed)
        {
            //
        }
    }

    public PlayerSpeed PlayerSpeed { get => _playerSpeed; private set => _playerSpeed = value; }
}