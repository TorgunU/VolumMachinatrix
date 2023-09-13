using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private Item _firstWeapon;
    [SerializeField] private Item _secondWeapon;
    [SerializeField] private List<Item> _items;

    protected int _maxItems;

    protected abstract void Awake();

    public virtual void AddItem(Item item)
    {
        if(_items.Count > 2)
        {
            return;
        }

        _items.Add(item);
    }

    public virtual void RemoveItem(int itemIndex)
    {
        if(itemIndex >  _items.Count)
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
