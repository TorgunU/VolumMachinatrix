using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : ItemInteraction, IItemSwitchable
{
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private List<Item> _itemsInRange;

    [SerializeField] private int _currentItemIndex;


    protected override void Awake()
    {
        //
        _itemsInRange = new List<Item>();

        PickupRange = 5;

        _currentItemIndex = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            Debug.Log("Item finded: " + item.gameObject.name);

            _itemsInRange.Add(item);

            if (_currentItemIndex == -1)
            {
                _currentItemIndex = 0;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if( _itemsInRange.Contains(item))
            {
                Debug.Log($"{item.gameObject.name} exit");

                _itemsInRange.Remove(item);
            }
        }
    }

    public override void TakeItem()
    {
        if (_itemsInRange.Count == 0)
        {
            // play audio "there aren't objects nearby"

            ResetCurrentItemIndex();

            Debug.Log("Item wasn't picked up");

            return;
        }
        else if(_itemsInRange[_currentItemIndex] == null)
        {
            Debug.LogError($"{_itemsInRange[_currentItemIndex].gameObject.name} is null");
        }

        Item currentItem = _itemsInRange[_currentItemIndex];

        _inventory.AddItem(currentItem);

        currentItem.Pickup();

        Debug.Log("Pickup item: " + currentItem.name);
    }

    public void SwitchItem()
    {
        if(_itemsInRange.Count == 0)
        {
            Debug.Log("No nearby items");

            ResetCurrentItemIndex();

            return;
        }

        if(_currentItemIndex == -1)
        {
            _currentItemIndex = 0;
        }
        else
        {
            _currentItemIndex = (_currentItemIndex + 1) % _itemsInRange.Count;
        }

        Debug.Log("Switched to item: " + _itemsInRange[_currentItemIndex].name);
    }

    private void ResetCurrentItemIndex()
    {
        _currentItemIndex = -1;
    }
}
