using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : ItemInteraction
{
    [SerializeField] private PlayerInventory _inventory;

    private Item _currentNeerestItem;

    protected override void Awake()
    {
        //
        PickupRange = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Item item))
        {
            Debug.Log("Item finded");

            _currentNeerestItem = item;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if(item == _currentNeerestItem)
            {
                Debug.Log("Item exit");

                _currentNeerestItem = null;
            }
        }
    }

    public override void TryPickupItem()
    {
        if(_currentNeerestItem == null)
        {
            // play audio "there aren't objects nearby"

            Debug.Log("Item wasn't picked up");

            return;
        }

        _inventory.AddItem(_currentNeerestItem);

        _currentNeerestItem.Pickup();

        Debug.Log("TryPickupItem Pressed ");
    }
}
