using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    [SerializeField] protected WeaponConfig WeaponConfig;

    public override void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        Hit(Crosshair.transform.position);

        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }

    protected abstract void Hit(Vector2 aimPosition);
}
