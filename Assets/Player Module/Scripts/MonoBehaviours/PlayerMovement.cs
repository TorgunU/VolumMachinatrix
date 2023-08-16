using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;

    private IMovementEvents _inputEvents;
    private Rigidbody2D _rigidbody2D;
    private ILegRotaionLimiter _legsRotaionLimiter;
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

    private void Awake()
    {
        _legsRotaionLimiter = GetComponentInChildren<ILegRotaionLimiter>();
    }

    private void Start()
    {
        _movingSpeed = 7;
        _runningSpeed = 25;
        _walkingSpeed = 2;
    }

    private void Update()
    {
        RotateLegs();
        Move();
    }

    private void OnEnable()
    {
        _inputEvents.MovementDirectionUpdated += SetMoveDirection;
        _inputEvents.WalkStateChanged += SetWalkState;
        _inputEvents.RunStateChanged += SetRunState;
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

        float legsAngle = _legsRotaionLimiter.GetLegsRoationAngle();
      
        Vector2 legsDirection = new Vector2(Mathf.Cos(legsAngle * Mathf.Deg2Rad), 
            Mathf.Cos(legsAngle * Mathf.Deg2Rad)).normalized;

        Vector2 moveDirection = Vector2.Scale(legsDirection, _moveDirection.normalized);

        //Debug.DrawRay(transform.position, legsDirection, Color.black);
        //Debug.DrawRay(transform.position, moveDirection, Color.green);

        _rigidbody2D.MovePosition(_rigidbody2D.position + moveDirection * scaledMoveSpeed);
    }

    private void RotateLegs()
    {
        _legsRotaionLimiter.Rotate(_moveDirection);
    }

    private void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;

        Debug.Log($"X: {_moveDirection.x}, Y: {_moveDirection.y} ");
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