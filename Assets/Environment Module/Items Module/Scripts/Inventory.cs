using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected List<Item> _firstItemsSlot;

    [SerializeField] private Item _firstWeapon;

    protected int _firstItemsSlotCapacity;

    protected abstract void Awake();

    public abstract bool TryAddItem(Item item);

    public virtual void RemoveItem(int itemIndex)
    {
        if(itemIndex > _firstItemsSlot.Count)
        {
            Debug.Log("Item increase items count");
            return;
        }

        _firstItemsSlot.RemoveAt(itemIndex);
    }

    public bool TryGetItem(int itemIndex, out Item item)
    {
        if (itemIndex > _firstItemsSlot.Count)
        {
            item = null;
            return false;
        }

        item = _firstItemsSlot[itemIndex];
        return true;
    }

    protected abstract bool TryAddInFirstItemsSlot(Item item);

    public abstract int FirstItemsSlotCapacity { get; protected set; }
}
