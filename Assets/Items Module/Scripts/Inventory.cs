using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected List<Item> _items;

    [SerializeField] private Item _firstWeapon;
    [SerializeField] private Item _secondWeapon;

    protected int _maxItems;

    protected abstract void Awake();

    public virtual bool TryAddItem(Item item)
    {
        if (_items.Count == _maxItems)
        {
            Debug.Log($"Can't add more items in player inventory. " +
                $"Current: {_items.Count}/MaxItems: {_maxItems}");

            return false;
        }

        _items.Add(item);
        return true;
    }

    public virtual void RemoveItem(int itemIndex)
    {
        if(itemIndex > _items.Count)
        {
            Debug.Log("Item increase items count");
            return;
        }

        _items.RemoveAt(itemIndex);
    }

    public bool TryGetItem(int itemIndex, out Item item)
    {
        if (itemIndex > _items.Count)
        {
            item = null;
            return false;
        }

        item = _items[itemIndex];
        return true;
    }

    public abstract int MaxItems { get; protected set; }
}
