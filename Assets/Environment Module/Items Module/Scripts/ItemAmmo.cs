using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmmo : Item
{
    public override void Pickup()
    {
        gameObject.SetActive(false);
    }

    public override void Use()
    {
        //
    }
}
