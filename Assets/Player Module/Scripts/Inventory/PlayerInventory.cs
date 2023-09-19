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
        SetSlotItemsFlag();

        if(IsItemSlotSelected() == false)
        {
            _currentSlotItems = null;
            return;
        }

        _currentSlotItems = FirstSlotItems;
    }

    public void OnFirstWeaponSlotPressed()
    {
        SetCurrentSlotWeaponFlag();

        if(IsWeaponSelected() == false)
        {
            _currentWeapon = null;
            return;
        }

        _currentWeapon = FirstWeaponSlot;
    }

    public override bool TryAddItem(Item item)
    {
        //if (_isCurrentItemSlotSelected == false)
        //{
        //    return false;
        //}

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

    private void SetSlotItemsFlag()
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

    private void SetCurrentSlotWeaponFlag()
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
}
