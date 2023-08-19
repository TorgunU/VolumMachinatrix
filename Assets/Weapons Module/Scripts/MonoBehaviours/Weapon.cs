using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Transform WeaponPosition;
    [SerializeField] protected WeaponSO WeaponConfig;

    protected bool IsAttackCooldowned;

    public abstract void Attack();
    public abstract IEnumerator CalculatingAttackDelay();
}