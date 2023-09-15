using System;
using System.Collections;
using System.Collections.Generic;
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
        if (ItemsSlot.Count == ItemsSlot.Capacity)
        {
            return false;
        }

        ItemsSlot.Add(item);

        OnAdded?.Invoke(item.GetComponent<SpriteRenderer>().sprite, ItemsSlot.Count);
        // invoke event

        return true;
    }

    public virtual bool TryRemoveLastItem(out Item droppableItem)
    {
        if (ItemsSlot.Count == 0)
        {
            Debug.Log("Slot items is empty!");

            droppableItem = null;
            return false;
        }

        droppableItem = ItemsSlot[ItemsSlot.Count - 1];
        ItemsSlot.RemoveAt(ItemsSlot.Count - 1);

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

    public event Action<Sprite, int> OnAdded;
}
