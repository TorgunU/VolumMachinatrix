using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlotInventory : MonoBehaviour
{
    [SerializeField] protected bool IsSlotSelected;

    protected abstract void Awake();

    public abstract void SelectSlot(int slotNumber);

    protected abstract void OnFirstSlotSelected();

    public event Action<int> SlotSelected;
    public event Action SlotUnselected;
}
