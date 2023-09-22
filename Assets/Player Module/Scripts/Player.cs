using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ItemInteractionDisplay _itemInteractionDisplay;
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerRangeAiming _rangeAiming;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private BodyRotation _bodyRotation;
    [SerializeField] private Transform _bulletsPool;

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
    private Crosshair _crosshair;
    private PlayerInteraction _interaction;
    private WeaponInjector _weaponInjector;

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
        _crosshair = GetComponentInChildren<Crosshair>();
        _interaction = GetComponentInChildren<PlayerInteraction>();
    }

    private void OnEnable()
    {
        _itemInteractionEvents.PickupPressed += _interaction.TakeItem;
        _itemInteractionEvents.DropPressed += _interaction.DropItemFromInventory;
        _itemInteractionEvents.SwitchPressed += _interaction.SwitchItem;

        _inventoryManipulationEvents.FirstSlotItemsPressed += _inventory.OnFirstItemSlotPressed;
        _inventoryManipulationEvents.FirstWeaponSlotPressed += _inventory.OnFirstWeaponSlotPressed;

        _interaction.OnItemInRangeSelected += _itemInteractionDisplay.OnSelected;
        _interaction.OnItemInRangeDeselected += _itemInteractionDisplay.OnDeselected;
        _interaction.OnTryingAddedItemInRange += _inventory.TryAddItem;
        _interaction.OnTryingRemoveItemFromInventory += _inventory.RemoveItem;
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
        _interaction.OnTryingRemoveItemFromInventory -= _inventory.RemoveItem;

        _inventoryManipulationEvents.FirstSlotItemsPressed -= _inventory.OnFirstItemSlotPressed;
        _inventoryManipulationEvents.FirstWeaponSlotPressed -= _inventory.OnFirstWeaponSlotPressed;

        _inventory.OnInventoryManipulated -= _inventoryPanel.OnInventoryPressed;
        _inventory.OnItemSlotSelected -= _inventoryPanel.OnItemSlotSelected;
        _inventory.OnItemSlotUnselected -= _inventoryPanel.OnRemovedHighlightItemViewer;
        _inventory.FirstSlotItems.OnAdded -= _inventoryPanel.OnFirstItemSlotSetted;
        _inventory.FirstSlotItems.OnUpdated -= _inventoryPanel.OnFirstItemSlotUpdated;
        _inventory.FirstSlotItems.OnEmpty -= _inventoryPanel.OnFirstItemSlotResseted;
        _inventory.FirstWeaponSlot.OnItemAdded -= _inventoryPanel.OnFirstWeaponSlotSetted;
        _inventory.FirstWeaponSlot.OnEmpty -= _inventoryPanel.OnFirstWeaponSlotResetted;
        _inventory.OnWeaponSlotSelected -= _inventoryPanel.OnWeaponlotSelected;
        _inventory.OnWeaponSlotUnselected -= _inventoryPanel.OnRemovedHighlightWeaponViewer;
    }

    private void Start()
    {
        _movement.Init(
            _rigidbody2D,
            _movementsInput,
            _movementStateEvents);

        _rangeAiming = new PlayerRangeAiming(_crosshair, _aimingInput, _movement.PlayerSpeed);

        _attack = new PlayerAttack();

        _weaponInjector = new WeaponInjector(_attack, _crosshair, _bulletsPool, _rangeAiming);

        _inventory.OnInventoryManipulated += _inventoryPanel.OnInventoryPressed;

        _inventory.OnItemSlotSelected += _inventoryPanel.OnItemSlotSelected;
        _inventory.OnItemSlotUnselected += _inventoryPanel.OnRemovedHighlightItemViewer;

        _inventory.FirstSlotItems.OnAdded += _inventoryPanel.OnFirstItemSlotSetted;
        _inventory.FirstSlotItems.OnUpdated += _inventoryPanel.OnFirstItemSlotUpdated;
        _inventory.FirstSlotItems.OnEmpty += _inventoryPanel.OnFirstItemSlotResseted;

        _inventory.FirstWeaponSlot.OnItemAdded += _inventoryPanel.OnFirstWeaponSlotSetted;
        _inventory.FirstWeaponSlot.OnEmpty += _inventoryPanel.OnFirstWeaponSlotResetted;
        _inventory.OnWeaponSlotSelected += _inventoryPanel.OnWeaponlotSelected;
        _inventory.OnWeaponSlotUnselected += _inventoryPanel.OnRemovedHighlightWeaponViewer;

        _inventory.FirstWeaponSlot.OnWeaponEquipped += WeaponEquippedInFirstSlotHandle;

        // OnRemove in inventory panel
    }

    private void WeaponEquippedInFirstSlotHandle(GameObject weapon)
    {
        _attacksInput.AttackPressed += _attack.Attack;
        _reloadInput.ReloadPressed += _attack.Reload;

        _weaponInjector.Init(weapon.GetComponent<Weapon>());
    }
}
