using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private Transform _firstWeaponSlotTransofrm;

    protected bool IsItemSlotSelected;
    protected bool IsWeaponSlotSelected;

    private SlotWeapon _currentSlotWeapon;
    private SlotItems _currentSlotItems;

    protected override void Awake()
    {
        SlotItemsCapacity = 2;
        FirstSlotItems = new SlotItems(SlotItemsCapacity);

        IsItemSlotSelected = false;

        FirstWeaponSlot = new SlotWeapon(_firstWeaponSlotTransofrm);

        IsWeaponSlotSelected = false;
    }

    public void OnFirstItemSlotPressed()
    {
        SelectItemSlot(1);
    }

    public void OnFirstWeaponSlotPressed()
    {
        SelectWeaponSlot(1);
    }

    public override bool TryAddItem(Item item)
    {
        if (item == null)
        {
            return false;
        }

        switch (item.ItemType)
        {
            case ItemType.Weapon:

                if (IsWeaponSlotSelected == false)
                    return false;

                return CurrentSlotWeapon.TryAddItem(item);

            case ItemType.Ammo:

                //
                break;

            case ItemType.Useable:

                if(IsItemSlotSelected == false)
                    return false;

                return CurrentSlotItems.TryAddItem(item);
        }

        return false;
    }

    public override Item RemoveItem()
    {
        if (IsItemSlotSelected && IsWeaponSlotSelected)
        {
            return null;
        }

        if (IsItemSlotSelected)
        {
            if(CurrentSlotItems.TryRemoveItem(out Item dropableItem))
                return dropableItem;
        }
        else if(IsWeaponSlotSelected)
        {
            if(CurrentSlotWeapon.TryRemoveItem(out Item dropableWeapon))
                return dropableWeapon;
        }

        return null;
    }

    public void OnFadedInventoryPanel()
    {
        IsItemSlotSelected = false;
    }

    private void SelectItemSlot(int slotItemsNumber)
    {
        ToggleIsItemSlotSelected();

        if (IsItemSlotSelected)
        {
            OnItemSlotSelected?.Invoke(slotItemsNumber);
        }
        else if (IsItemSlotSelected == false)
        {
            OnItemSlotUnselected?.Invoke();
            CurrentSlotItems = null;
            return;
        }

        switch (slotItemsNumber)
        {
            case 1:
                SetCurrentItemSlot(FirstSlotItems);
                break;
            default:
                return;
        }
    }

    private void SelectWeaponSlot(int slotWeaponNumber)
    {
        ToggleIsWeaponSlotSelected();

        if (IsWeaponSlotSelected)
        {
            OnWeaponSlotSelected?.Invoke(slotWeaponNumber);
        }
        else if (IsWeaponSlotSelected == false)
        {
            OnWeaponSlotUnselected?.Invoke();
            CurrentSlotWeapon = null;
            return;
        }

        switch (slotWeaponNumber)
        {
            case 1:
                SetCurrentWeaponSlot(FirstWeaponSlot);
                break;
            default:
                return;
        }
    }

    private void SetCurrentItemSlot(SlotItems selectedSlotItems)
    {
        CurrentSlotItems = selectedSlotItems;
    }

    private void SetCurrentWeaponSlot(SlotWeapon selectedSlotWeapon)
    {
        CurrentSlotWeapon = selectedSlotWeapon;
    }

    private void ToggleIsItemSlotSelected()
    {
        IsItemSlotSelected = !IsItemSlotSelected;
        OnInventoryManipulated?.Invoke();
    }

    private void ToggleIsWeaponSlotSelected()
    {
        IsWeaponSlotSelected = !IsWeaponSlotSelected;
        OnInventoryManipulated?.Invoke();
    }

    public SlotWeapon CurrentSlotWeapon
    {
        get => _currentSlotWeapon;
        protected set => _currentSlotWeapon = value;
    }

    public SlotItems CurrentSlotItems
    {
        get => _currentSlotItems;
        protected set => _currentSlotItems = value;
    }

    public event Action OnInventoryManipulated;
    public event Action OnItemSlotUnselected;
    public event Action OnWeaponSlotUnselected;
    public event Action<int> OnItemSlotSelected;
    public event Action<int> OnWeaponSlotSelected;
}
