using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : Inventory
{
    protected override void Awake()
    {
        _maxItems = 2;

        _items = new List<Item>(_maxItems);
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
