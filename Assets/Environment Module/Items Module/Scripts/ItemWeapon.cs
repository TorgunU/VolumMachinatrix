using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : Item
{
    public override void Pickup()
    {
        // some events to take in ammo bar and change player weapon
        gameObject.SetActive(false);
    }
}
