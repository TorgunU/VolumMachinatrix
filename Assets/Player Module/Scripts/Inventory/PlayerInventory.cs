using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] protected List<Item> _secondItemsSlot;
    [SerializeField] private Item _secondWeapon;

    protected int _secondItemsSlotCapacity;

    protected override void Awake()
    {
        _firstItemsSlotCapacity = 2;

        _firstItemsSlot = new List<Item>(_firstItemsSlotCapacity);
    }

    public override bool TryAddItem(Item item)
    {
        switch (item.ItemType)
        {
            case ItemType.Weapon:

                break;

            case ItemType.Ammo:

                if (TryAddInFirstItemsSlot(item))
                {
                    return true;
                }

                break;

            case ItemType.Useable:

                if(TryAddInFirstItemsSlot(item))
                {
                    return true;
                }

                // try add in second

                break;
        }

        return false;
    }

    public override void RemoveItem(int itemIndex)
    {
        base.RemoveItem(itemIndex);

        //OnRemoved?.Invoke(itemIndex);
    }

    protected override bool TryAddInFirstItemsSlot(Item item)
    {
        if (_firstItemsSlot.Count == _firstItemsSlotCapacity)
        {
            return false;
        }

        _firstItemsSlot.Add(item);

        OnAdded?.Invoke(item.GetComponent<SpriteRenderer>().sprite, _firstItemsSlot.Count);
        // invoke event

        return true;
    }

    //public void SwitchItemSlot(List<Item> slotItems)
    //{
    //    Item currentItem = (_currentItemIndex + 1) % _itemsInRange.Count;
    //}

    public override int FirstItemsSlotCapacity 
    { 
        get => _firstItemsSlotCapacity; 
        protected set => _firstItemsSlotCapacity = value; 
    }

    public event Action<Sprite, int> OnAdded;
    //public event Action<int> OnRemoved;
}
