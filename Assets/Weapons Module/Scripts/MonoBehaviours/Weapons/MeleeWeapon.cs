using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    [SerializeField] protected WeaponConfig WeaponConfig;

    protected override void PerformAttack()
    {
        Vector2 aimPosition = Crosshair.transform.position;
        Hit(aimPosition);
    }

    protected abstract void Hit(Vector2 aimPosition);
}