using System;
using UnityEngine;

public class SlotWeapon : ISlotItem
{
    protected ItemWeapon ItemWeapon;
    protected Transform WeaponTransform;

    public SlotWeapon(Transform slotTransform)
    {
        WeaponTransform = slotTransform;
    }

    public void RaiseOnEmpty()
    {
        OnEmpty?.Invoke();
    }

    public bool TryAddItem(Item item)
    {
        if (IsSlotEmpty() == false)
        {
            return false;
        }

        ItemWeapon = (ItemWeapon)item;

        SetWeaponToSlot();

        OnItemAdded?.Invoke(ItemWeapon.Sprite);

        return true;
    }

    public bool TryRemoveItem(out Item item)
    {
        if(IsSlotEmpty())
        {
            item = null;
            return false;
        }

        SetWeaponFromSlot();

        item = ItemWeapon;

        ItemWeapon = null;

        OnEmpty?.Invoke();

        return true;
    }

    public bool IsSlotEmpty()
    {
        return ItemWeapon == null;
    }

    private void SetWeaponFromSlot()
    {
        WeaponTransform.GetChild(0).SetParent(ItemWeapon.transform);

        ItemWeapon.transform.GetChild(0).gameObject.SetActive(false);

        OnWeaponUnequipped?.Invoke();
    }

    private void SetWeaponToSlot()
    {
        ItemWeapon.transform.GetChild(0).SetParent(WeaponTransform);

        GameObject weapon = WeaponTransform.GetChild(0).gameObject;
        weapon.transform.position = WeaponTransform.position;
        weapon.SetActive(true);

        OnWeaponEquipped?.Invoke(weapon);
    }

    public event Action OnEmpty;
    public event Action<Sprite> OnItemAdded;
    public event Action<GameObject> OnWeaponEquipped;
    public event Action OnWeaponUnequipped;
    //public event Action
}
