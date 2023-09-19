using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SlotItems
{
    [SerializeField] protected List<Item> Items;

    public SlotItems(int slotCapacity)
    {
        Items = new List<Item>(slotCapacity);
    }

    public bool TryAddItem(Item item)
    {
        if(IsSlotReachedMax())
        {
            Debug.Log($"Item slot's has reached max!");
            return false;
        }

        Items.Add(item);

        if (Items.Count == 1)
        {
            OnAdded?.Invoke(item.Sprite, Items.Count);
        }
        else
        {
            OnUpdated?.Invoke(Items.Count);
        }

        return true;
    }

    public virtual bool TryRemoveLastItem(out Item droppableItem)
    {
        if (IsSlotEmpty())
        {
            Debug.Log($"Item slot's empty!");

            droppableItem = null;
            return false;
        }

        droppableItem = Items[Items.Count - 1];

        Items.RemoveAt(Items.Count - 1);

        if (Items.Count > 0)
        {
            OnUpdated?.Invoke(Items.Count);
        }
        else
        {
            OnEmpty?.Invoke();
        }

        return true;
    }

    public bool TryGetItem(int itemIndex, out Item item)
    {
        if (itemIndex > Items.Count)
        {
            item = null;
            return false;
        }

        item = Items[itemIndex];
        return true;
    }

    private bool IsSlotReachedMax()
    {
        return Items.Count == Items.Capacity;
    }

    private bool IsSlotEmpty()
    {
        return Items.Count == 0;
    }

    public event Action<Sprite, int> OnAdded;
    public event Action<int> OnUpdated;
    public event Action OnEmpty;
}
