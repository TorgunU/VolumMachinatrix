using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SlotWeapon
{
    protected ItemWeapon ItemWeapon;

    public bool TryAddItem(Item item)
    {
        if (IsSlotEmpty() == false)
        {
            return false;
        }

        ItemWeapon = (ItemWeapon)item;

        OnAdded?.Invoke(ItemWeapon.Sprite);

        return true;
    }

    public bool TryRemoveItem(out Item item)
    {
        if(IsSlotEmpty())
        {
            item = null;
            return false;
        }

        item = ItemWeapon;

        OnRemoved?.Invoke();

        return true;
    }

    private bool IsSlotEmpty()
    {
        return ItemWeapon == null;
    }

    public event Action<Sprite> OnAdded;
    public event Action OnRemoved;
}
