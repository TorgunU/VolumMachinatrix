using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponShootable : IWeaponAttackable
{
    public abstract void PerformRangeAttack(Vector2 aimDirection);
}
