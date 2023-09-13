using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    protected override void Awake()
    {
        _maxItems = 4;
    }

    public override void AddItem(Item item)
    {
        base.AddItem(item);

        //OnAdded?.Invoke();
    }

    public override void RemoveItem(int itemIndex)
    {
        base.RemoveItem(itemIndex);

        //OnRemoved?.Invoke(itemIndex);
    }

    public override int MaxItems { get => _maxItems; protected set => _maxItems = value; }

    public event Action<int> OnAdded;
    public event Action<int> OnRemoved;
}
