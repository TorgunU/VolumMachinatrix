using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private SlotWeapon _firstWeaponSlot;
    [SerializeField] private SlotItems _firstSlotItems;

    protected int SlotItemsCapacity;

    protected abstract void Awake();

    public abstract bool TryAddItem(Item item);
    public abstract Item RemoveItem();
    //public abstract Item RemoveWeapon();

    public SlotItems FirstSlotItems 
    { 
        get => _firstSlotItems; 
        protected set => _firstSlotItems = value; 
    }

    public SlotWeapon FirstWeaponSlot
    {
        get => _firstWeaponSlot;
        protected set => _firstWeaponSlot = value;
    }
}
