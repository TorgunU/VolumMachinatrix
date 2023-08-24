using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected Transform FireTrasform;

    public override void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        Shoot();

        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }

    public abstract void Shoot();
}
