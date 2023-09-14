using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInteraction : MonoBehaviour, IItemTakeable
{
    [SerializeField] protected float PickupRange;

    protected abstract void Awake();

    public abstract void TakeItem();
}
