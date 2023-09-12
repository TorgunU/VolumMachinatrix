using System;
using UnityEngine;

[Serializable]
public class PlayerAttack : IAttackeable, IReloadable
{
    protected Weapon Weapon;

    public PlayerAttack(Weapon weapon)
    {
        Weapon = weapon;
    }

    public void InjectWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }

    public void Attack()
    {
        if (Weapon == null)
            return;

        Weapon.Attack();
    }

    public void Reload()
    {
        if (Weapon == null) 
            return;

        if (Weapon is RangeWeapon rangeWeapon == false)
            return;

        rangeWeapon.Reload();
    }
}