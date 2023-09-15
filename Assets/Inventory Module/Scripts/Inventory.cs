using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected Item FirstWeapon;

    [SerializeField] private SlotItems _firstSlotItems;

    protected int SlotItemsCapacity;

    protected abstract void Awake();

    public abstract bool TryAddItem(Item item);
    public abstract Item RemoveItem();

    public SlotItems FirstSlotItems 
    { 
        get => _firstSlotItems; 
        protected set => _firstSlotItems = value; 
    }
}
