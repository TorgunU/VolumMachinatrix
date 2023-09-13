using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmmo : Item
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {

        }
    }

    public override void Pickup()
    {
        gameObject.SetActive(false);
    }

    public override void Use()
    {
        //
    }
}
