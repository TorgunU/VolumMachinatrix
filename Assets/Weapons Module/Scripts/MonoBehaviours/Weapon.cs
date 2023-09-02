using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Crosshair Crosshair;

    protected SpriteRenderer SpriteRenderer;
    protected bool IsAttackCooldowned = true;

    private Coroutine _attackDelayCorutine;

    public abstract void PerformAttack();
    public abstract IEnumerator CalculatingAttackDelay();

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
}