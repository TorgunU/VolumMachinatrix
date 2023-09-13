using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInteraction : MonoBehaviour
{
    [SerializeField] protected float PickupRange;

    protected abstract void Awake();

    public abstract void TryPickupItem();
}
