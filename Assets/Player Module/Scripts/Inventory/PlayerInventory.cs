using System;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private bool _isItemSlotSelected;
    [SerializeField] private bool _isWeaponSlotSelected;

    private SlotWeapon _currentWeapon;
    private SlotItems _currentSlotItems;

    protected override void Awake()
    {
        SlotItemsCapacity = 2;
        FirstSlotItems = new SlotItems(SlotItemsCapacity);

        _isItemSlotSelected = false;
        _currentSlotItems = null;

        FirstWeaponSlot = new SlotWeapon();
        _currentWeapon = null;

        _isWeaponSlotSelected = false;
    }

    public void OnFirstItemSlotPressed()
    {
        SelectItemSlot(1);
    }

    public void OnFirstWeaponSlotPressed()
    {
        SelectWeaponSlot(1);
    }

    public override bool TryAddItem(Item item)
    {
        if (item == null)
        {
            return false;
        }

        switch (item.ItemType)
        {
            case ItemType.Weapon:

                if (IsWeaponSelected() == false)
                    return false;

                return _currentWeapon.TryAddItem(item);

            case ItemType.Ammo:

                //
                break;

            case ItemType.Useable:

                if (IsItemSlotSelected() == false)
                    return false;

                return _currentSlotItems.TryAddItem(item);
        }

        return false;
    }

    public override Item RemoveItem()
    {
        if (_isItemSlotSelected == false)
        {
            return null;
        }

        if (_currentSlotItems.TryRemoveLastItem(out Item dropableItem) == false)
        {
            // play effect can't get item

            return null;
        }

        return dropableItem;
    }

    public void OnFadedInventoryPanel()
    {
        _isItemSlotSelected = false;
    }

    private void SelectItemSlot(int slotItemsNumber)
    {
        ToggleIsSlotItemsSelected();

        ItemSlotSelected?.Invoke(slotItemsNumber);

        if (IsItemSlotSelected() == false)
        {
            ItemSlotUnselected?.Invoke();
            _currentSlotItems = null;
            return;
        }

        switch (slotItemsNumber)
        {
            case 1:
                SetCurrentItemSlot(FirstSlotItems);
                break;
            default:
                return;
        }
    }

    private void SelectWeaponSlot(int slotWeaponNumber)
    {
        ToggleIsSlotIWeaponSelected();

        WeaponSlotSelected?.Invoke(slotWeaponNumber);

        if (IsWeaponSelected() == false)
        {
            WeaponSlotSUnselected?.Invoke();
            _currentSlotItems = null;
            return;
        }

        switch (slotWeaponNumber)
        {
            case 1:
                SetCurrentWeaponSlot(FirstWeaponSlot);
                break;
            default:
                return;
        }
    }

    private void SetCurrentItemSlot(SlotItems selectedSlotItems)
    {
        _currentSlotItems = selectedSlotItems;
    }

    private void SetCurrentWeaponSlot(SlotWeapon selectedSlotWeapon)
    {
        _currentWeapon = selectedSlotWeapon;
    }

    private void ToggleIsSlotItemsSelected()
    {
        _isItemSlotSelected = !_isItemSlotSelected;

        InventoryManipulated?.Invoke();
    }

    private bool IsItemSlotSelected()
    {
        if (_isItemSlotSelected)
        {
            return true;
        }

        return false;
    }

    private void ToggleIsSlotIWeaponSelected()
    {
        _isWeaponSlotSelected = !_isWeaponSlotSelected;

        InventoryManipulated?.Invoke();
    }

    private bool IsWeaponSelected()
    {
        if (_isWeaponSlotSelected)
        {
            return true;
        }

        return false;
    }

    public event Action InventoryManipulated;
    public event Action<int> ItemSlotSelected;
    public event Action ItemSlotUnselected;
    public event Action<int> WeaponSlotSelected;
    public event Action WeaponSlotSUnselected;
}
