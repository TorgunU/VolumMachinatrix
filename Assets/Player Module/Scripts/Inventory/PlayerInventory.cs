using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private Item _secondWeapon;

    private SlotItems _currentSlotItems;
    private bool _isCurrentSlotSelected;

    protected override void Awake()
    {
        SlotItemsCapacity = 2;
        FirstSlotItems = new SlotItems(SlotItemsCapacity);

        _isCurrentSlotSelected = false;
        _currentSlotItems = FirstSlotItems;
    }

    public void OnFirstItemSlotPressed()
    {
        SetCurrentSlotFlag();

        if (_isCurrentSlotSelected == false)
        {            
            _currentSlotItems = null;
            return;
        }

        _currentSlotItems = FirstSlotItems;

        // some selected panel effects
    }

    public override bool TryAddItem(Item item)
    {
        if (_isCurrentSlotSelected == false)
        {
            // fade in slot panel

            return false;
        }

        switch (item.ItemType)
        {
            case ItemType.Weapon:

                break;

            case ItemType.Ammo:

                break;

            case ItemType.Useable:

                if (_currentSlotItems.TryAddItem(item))
                {
                    return true;
                }

                break;
        }

        return false;
    }

    public override Item RemoveItem()
    {
        if (_isCurrentSlotSelected == false)
        {
            // fade in slot panel

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
        _isCurrentSlotSelected = false;
    }

    private void SetCurrentSlotFlag()
    {
        _isCurrentSlotSelected = !_isCurrentSlotSelected;

        InventoryManipulated?.Invoke();
    }

    public event Action InventoryManipulated;
}
