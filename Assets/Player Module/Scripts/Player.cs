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

    private void OnEnable()
    {
        _attacksInput.AttackPressed += _attack.Attack;
        _reloadInput.ReloadPressed += _attack.Reload;
        _itemInteractionEvents.PickupPressed += _interaction.TakeItem;
        _itemInteractionEvents.DropPressed += _interaction.DropItemFromInventory;
        _itemInteractionEvents.SwitchPressed += _interaction.SwitchItem;

        _interaction.OnItemInRangeSelected += _itemInteractionDisplay.OnSelected;
        _interaction.OnItemInRangeDeselected += _itemInteractionDisplay.OnDeselected;
        _interaction.OnTryingAddedItemInRange += _inventory.TryAddItem;
        _interaction.OnTryingRemoveItemFromInventory += _inventory.RemoveItem;

        _inventoryManipulationEvents.FirstSlotItemsPressed += _inventory.OnFirstItemSlotPressed;

        //_inventory.FirstSlotItems.OnAdded += _inventoryPanel.OnFirstSlotSetted;
        //_inventory.FirstSlotItems.OnUpdated += _inventoryPanel.OnFirstSlotUpdated;
        //_inventory.FirstSlotItems.OnEmpty += _inventoryPanel.OnFirstSlotResseted;
    }

    private void OnDisable()
    {
        _attacksInput.AttackPressed -= _attack.Attack;
        _reloadInput.ReloadPressed -= _attack.Reload;

        _itemInteractionEvents.PickupPressed -= _interaction.TakeItem;
        _itemInteractionEvents.DropPressed -= _interaction.DropItemFromInventory;
        _itemInteractionEvents.SwitchPressed -= _interaction.SwitchItem;

        _interaction.OnItemInRangeSelected -= _itemInteractionDisplay.OnSelected;
        _interaction.OnItemInRangeDeselected -= _itemInteractionDisplay.OnDeselected;

        _inventory.InventoryManipulated -= _inventoryPanel.OnInventoryPressed;
        _inventory.FirstSlotItems.OnAdded -= _inventoryPanel.OnFirstSlotSetted;
        _inventory.FirstSlotItems.OnUpdated -= _inventoryPanel.OnFirstSlotUpdated;
        _inventory.FirstSlotItems.OnEmpty -= _inventoryPanel.OnFirstSlotResseted;

        _inventoryPanel.PanelFadedIn -= _inventory.OnFadedInventoryPanel;
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

        _inventory.InventoryManipulated += _inventoryPanel.OnInventoryPressed;
        _inventory.FirstSlotItems.OnAdded += _inventoryPanel.OnFirstSlotSetted;
        _inventory.FirstSlotItems.OnUpdated += _inventoryPanel.OnFirstSlotUpdated;
        _inventory.FirstSlotItems.OnEmpty += _inventoryPanel.OnFirstSlotResseted;

        _inventoryPanel.PanelFadedIn += _inventory.OnFadedInventoryPanel;

        // OnRemove in inventory panel
    }
}
