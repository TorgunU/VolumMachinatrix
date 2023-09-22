using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : ItemInteraction, IItemSwitchable
{
    [SerializeField] private int _currentItemIndex;

    private Item _selectedItem;
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
                _selectedItem = _itemsInRange[0];

                OnItemInRangeSelected?.Invoke(_selectedItem);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (_itemsInRange.Contains(item))
            {
                if (_selectedItem == item && IsOtherItemsInRange())
                {
                    SwitchItem();
                }
                else
                {
                    OnItemInRangeDeselected?.Invoke();
                    ClearListInRange();
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

        Item currentItem = _selectedItem;

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
            ClearListInRange();
            return;
        }

        OnItemInRangeDeselected?.Invoke();

        _currentItemIndex = (_currentItemIndex + 1) % _itemsInRange.Count;
        _selectedItem = _itemsInRange[_currentItemIndex];

        OnItemInRangeSelected?.Invoke(_selectedItem);
    }

    public void DropItemFromInventory()
    {
        Item item = OnTryingRemoveItemFromInventory?.Invoke();

        if (item == null)
        {
            return;
        }

        item.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            item.transform.position.z);

        item.gameObject.SetActive(true);
    }

    private bool IsOtherItemsInRange()
    {
        if (_itemsInRange.Count <= 1)
        {
            Debug.Log("No nearby items");
            return false;
        }

        return true;
    }

    private void ClearListInRange()
    {
        //_itemsInRange.Clear();
        _currentItemIndex = 0;
        _selectedItem = null;
    }

    public event Func<Item, bool> OnTryingAddedItemInRange;
    public event Func<Item> OnTryingRemoveItemFromInventory;
    public event Action<Item> OnItemInRangeSelected;
    public event Action OnItemInRangeDeselected;
}
