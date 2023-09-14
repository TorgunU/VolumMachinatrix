using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ItemInteractionDisplay _itemInteractionDisplay;
    [SerializeField] private InventoryPanel _inventoryPanel;

    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerRangeAiming _playerRangeAiming;
    [SerializeField] private PlayerInventory _inventory;

    private IMovementDirection _movementsInput;
    private IMovementStateEvents _movementStateEvents;
    private IAttackEvents _attacksInput;
    private IAimingEvents _aimingInput;
    private IReloadInputEvent _reloadInput;
    private IInteractionEvent _interactionEvent;
    private IItemInteractionEvents _itemInteractionEvents;
    private IInventoryManipulationEvents _inventoryManipulationEvents;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _movement;
    private Weapon _weapon;
    private Crosshair _crosshair;
    private PlayerInteraction _interaction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementsInput = GetComponent<PlayerInput>();
        _attacksInput = GetComponent<PlayerInput>();
        _aimingInput = GetComponent<PlayerInput>();
        _reloadInput = GetComponent<PlayerInput>();
        _movementStateEvents = GetComponent<PlayerInput>();
        _interactionEvent = GetComponent<PlayerInput>();
        _itemInteractionEvents = GetComponent<PlayerInput>();
        _inventoryManipulationEvents = GetComponent<PlayerInput>();

        _movement = GetComponentInChildren<PlayerMovement>();
        _weapon = GetComponentInChildren<Weapon>();
        _crosshair = GetComponentInChildren<Crosshair>();
        _interaction = GetComponentInChildren<PlayerInteraction>();

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
        _itemInteractionEvents.PickupPressed += _interaction.TakeItem;
        _itemInteractionEvents.SwitchPressed += _interaction.SwitchItem;
        //_interactionEvent.Interacted += _interaction.TryPickupItem;

        _interaction.OnItemSelected += _itemInteractionDisplay.OnSelected;
        _interaction.OnItemDeselected += _itemInteractionDisplay.OnDeselected;
        _interaction.OnTryingAddedItem += _inventory.TryAddItem;

        //_inventoryManipulationEvents.InventoryItemSelected += _inve

    }

    private void OnDisable()
    {
        _attacksInput.AttackPressed -= _attack.Attack;
        _reloadInput.ReloadPressed -= _attack.Reload;

        _itemInteractionEvents.PickupPressed -= _interaction.TakeItem;
        _itemInteractionEvents.SwitchPressed -= _interaction.SwitchItem;

        _interaction.OnItemSelected -= _itemInteractionDisplay.OnSelected;
        _interaction.OnItemDeselected -= _itemInteractionDisplay.OnDeselected;
    }
}