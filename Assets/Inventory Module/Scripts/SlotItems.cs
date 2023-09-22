using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SlotItems : ISlotItem
{
    [SerializeField] protected List<Item> Items;

    public SlotItems(int slotCapacity)
    {
        Items = new List<Item>(slotCapacity);
    }

    public void RaiseOnEmpty()
    {
        OnEmpty?.Invoke();
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

    public bool TryRemoveItem(out Item droppableItem)
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

    public bool IsSlotEmpty()
    {
        return Items.Count == 0;
    }

    private bool IsSlotReachedMax()
    {
        return Items.Count == Items.Capacity;
    }

    public event Action OnEmpty;
    public event Action<Sprite, int> OnAdded;
    public event Action<int> OnUpdated;
}
