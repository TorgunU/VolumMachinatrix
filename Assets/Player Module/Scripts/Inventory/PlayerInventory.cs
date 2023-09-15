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
        _currentSlotItems = FirstSlotItems;
        isCurrentSlotSelected = true;

        // some selected panel effects
    }

    public override bool TryAddItem(Item item)
    {
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
        if(_currentSlotItems.TryRemoveLastItem(out Item dropableItem) == false)
        {
            // play effect can't get item

            return null;
        }

        return dropableItem;
    }
}
