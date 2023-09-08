using System;
using UnityEngine;

[Serializable]
public class PlayerAttack : IAttackeable
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
}