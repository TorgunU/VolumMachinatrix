using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCastStratagy
{
    protected RangeRaycastWeaponConfig WeaponConfig;

    public virtual void Init(RangeRaycastWeaponConfig weaponConfig)
    {
        WeaponConfig = weaponConfig;
    }

    public abstract void Cast(Vector2 firePosition, Vector2 fireDirection);
}