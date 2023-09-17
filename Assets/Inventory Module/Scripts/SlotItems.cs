using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SlotItems
{
    [SerializeField] protected List<Item> ItemsSlot;

    public SlotItems(int slotCapacity)
    {
        ItemsSlot = new List<Item>(slotCapacity);
    }

    public bool TryAddItem(Item item)
    {
        if(IsSlotReachedMax())
        {
            Debug.Log($"Item slot's has reached max!");
            return false;
        }

        ItemsSlot.Add(item);

        if (ItemsSlot.Count == 1)
        {
            OnAdded?.Invoke(item.GetComponent<SpriteRenderer>().sprite, ItemsSlot.Count);
        }
        else
        {
            OnUpdated?.Invoke(ItemsSlot.Count);
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

        droppableItem = ItemsSlot[ItemsSlot.Count - 1];

        ItemsSlot.RemoveAt(ItemsSlot.Count - 1);

        if (ItemsSlot.Count > 0)
        {
            OnUpdated?.Invoke(ItemsSlot.Count);
        }
        else
        {
            OnEmpty?.Invoke();
        }

        return true;
    }

    public bool TryGetItem(int itemIndex, out Item item)
    {
        if (itemIndex > ItemsSlot.Count)
        {
            item = null;
            return false;
        }

        item = ItemsSlot[itemIndex];
        return true;
    }

    private bool IsSlotReachedMax()
    {
        return ItemsSlot.Count == ItemsSlot.Capacity;
    }

    private bool IsSlotEmpty()
    {
        return ItemsSlot.Count == 0;
    }

    public event Action<Sprite, int> OnAdded;
    public event Action<int> OnUpdated;
    public event Action OnEmpty;
}
