using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Crosshair Crosshair;
    [SerializeField] protected WeaponSprite WeaponSprite;

    protected bool IsAttackCooldowned = true;

    private Coroutine _attackDelayCorutine;

    public void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        PerformAttack();

        IsAttackCooldowned = false;

        _attackDelayCorutine = StartCoroutine(CalculatingAttackDelay());
    }

    public abstract IEnumerator CalculatingAttackDelay();

    protected abstract void PerformAttack();
}