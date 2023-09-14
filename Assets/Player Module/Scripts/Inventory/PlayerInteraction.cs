using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : ItemInteraction, IItemSwitchable
{
    [SerializeField] private int _currentItemIndex;

    private List<Item> _itemsInRange;

    protected override void Awake()
    {
        //
        _itemsInRange = new List<Item>();

        PickupRange = 5;

        _currentItemIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            Debug.Log("Item finded: " + item.gameObject.name);

            _itemsInRange.Add(item);

            if (_itemsInRange.Count == 1)
            {
                OnItemSelected?.Invoke(_itemsInRange[0]);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (_itemsInRange.Contains(item))
            {
                Debug.Log($"{item.gameObject.name} exit");

                if (_itemsInRange[0] == item && IsOtherItemsInRange())
                {
                    SwitchItem();
                }
                else
                {
                    OnItemDeselected?.Invoke();
                }

                _itemsInRange.Remove(item);
            }
        }
    }

    public override void TakeItem()
    {
        if(_itemsInRange.Count == 0)
        {
            return;
        }
        else if (_itemsInRange[_currentItemIndex] == null)
        {
            return;
        }

        Item currentItem = _itemsInRange[_currentItemIndex];

        if(OnTryingAddedItem?.Invoke(currentItem) == false)
        {
            return;
        }

        OnItemDeselected?.Invoke();

        currentItem.Pickup();

        Debug.Log("Pickup item: " + currentItem.name);
    }

    public void SwitchItem()
    {
        if(IsOtherItemsInRange() == false)
        {
            return;
        }

        OnItemDeselected?.Invoke();

        _currentItemIndex = (_currentItemIndex + 1) % _itemsInRange.Count;

        OnItemSelected?.Invoke(_itemsInRange[_currentItemIndex]);

        Debug.Log("Switched to item: " + _itemsInRange[_currentItemIndex].name);
    }

    private bool IsOtherItemsInRange()
    {
        if (_itemsInRange.Count <= 1)
        {
            _currentItemIndex = 0;
            Debug.Log("No nearby items");
            return false;
        }

        return true;
    }

    public event Func<Item, bool> OnTryingAddedItem;
    public event Action<Item> OnItemSelected;
    public event Action OnItemDeselected;
}
