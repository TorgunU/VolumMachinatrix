using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private Item _secondWeapon;

    private SlotItems _currentSlotItems;

    bool isCurrentSlotSelected;

    protected override void Awake()
    {
        SlotItemsCapacity = 2;
        FirstSlotItems = new SlotItems(SlotItemsCapacity);

        isCurrentSlotSelected = false;
        _currentSlotItems = FirstSlotItems;
    }

    public void OnFirstItemSlotPressed()
    {
        isCurrentSlotSelected = !isCurrentSlotSelected;

        if (isCurrentSlotSelected == false)
        {
            // fade in slot panel
            _currentSlotItems = null;
            return;
        }

        _currentSlotItems = FirstSlotItems;

        // some selected panel effects
    }

    public override bool TryAddItem(Item item)
    {
        if (isCurrentSlotSelected == false)
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
        if (isCurrentSlotSelected == false)
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
}
