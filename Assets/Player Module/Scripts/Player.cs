using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerRangeAiming _playerRangeAiming;

    private IMovementDirection _movementsInput;
    private IMovementStateEvents _movementStateEvents;
    private IAttackEvents _attacksInput;
    private IAimingEvents _aimingInput;
    private IReloadInputEvent _reloadInput;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _movement;
    private Weapon _weapon;
    private Crosshair _crosshair;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementsInput = GetComponent<PlayerInput>();
        _attacksInput = GetComponent<PlayerInput>();
        _aimingInput = GetComponent<PlayerInput>();
        _reloadInput = GetComponent<PlayerInput>();
        _movementStateEvents = GetComponent<PlayerInput>();

        _movement = GetComponentInChildren<PlayerMovement>();
        _weapon = GetComponentInChildren<Weapon>();
        _crosshair = GetComponentInChildren<Crosshair>();

        _attack = new PlayerAttack(_weapon);
    }

    private void Start()
    {
        _movement.Init(
            _rigidbody2D,
            _movementsInput,
            _movementStateEvents);


        if (_weapon is RangeWeapon rangeWeapon)
        {
            _playerRangeAiming = new PlayerRangeAiming(
                _crosshair,
                _aimingInput,
                _movement.PlayerSpeed,
                rangeWeapon.RangeWeaponConfig);
        }
    }

    private void OnEnable()
    {
        _attacksInput.AttackPressed += _attack.Attack;
        _reloadInput.ReloadPressed += _attack.Reload;
    }

    private void OnDisable()
    {
        _attacksInput.AttackPressed -= _attack.Attack;
        _reloadInput.ReloadPressed -= _attack.Reload;
    }
}