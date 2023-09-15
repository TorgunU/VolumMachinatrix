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

        _currentItemIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            _itemsInRange.Add(item);

            if (_itemsInRange.Count == 1)
            {
                OnItemInRangeSelected?.Invoke(_itemsInRange[0]);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (_itemsInRange.Contains(item))
            {
                if (_itemsInRange[0] == item && IsOtherItemsInRange())
                {
                    SwitchItem();
                }
                else
                {
                    OnItemInRangeDeselected?.Invoke();
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

        if(OnTryingAddedItemInRange?.Invoke(currentItem) == false)
        {
            return;
        }

        OnItemInRangeDeselected?.Invoke();

        currentItem.Pickup();
    }

    public void SwitchItem()
    {
        if(IsOtherItemsInRange() == false)
        {
            return;
        }

        OnItemInRangeDeselected?.Invoke();

        _currentItemIndex = (_currentItemIndex + 1) % _itemsInRange.Count;

        OnItemInRangeSelected?.Invoke(_itemsInRange[_currentItemIndex]);
    }

    public void DropItemFromInventory()
    {
        Item item = OnTryingRemoveItemFromInventory?.Invoke();

        if (item == null)
        {
            return;
        }

        item.gameObject.gameObject.SetActive(true);
        item.transform.position = transform.position;

        //OnTriggerEnter2D(item.GetComponent<Collider2D>());
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

    public event Func<Item, bool> OnTryingAddedItemInRange;
    public event Func<Item> OnTryingRemoveItemFromInventory;
    public event Action<Item> OnItemInRangeSelected;
    public event Action OnItemInRangeDeselected;
}
