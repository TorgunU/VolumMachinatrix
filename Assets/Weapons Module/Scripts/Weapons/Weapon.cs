using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Crosshair Crosshair;
    [SerializeField] protected WeaponSprite WeaponSprite;

    protected bool IsAttackCanceled = false;
    protected bool IsAttackCooldowned = true;

    protected Coroutine AttackDelayCorutine;

    public void Attack()
    {
        IsAttackCanceled = false;

        if (IsAttackCooldowned == false)
        {
            return;
        }

        PerformAttack();

        if(IsAttackCanceled)
        {
            return;
        }

        PlayAttackAudio();

        //PlayAttackAnimation();

        IsAttackCooldowned = false;

        AttackDelayCorutine = StartCoroutine(CalculatingAttackDelay());
    }

    protected virtual void OnDisable()
    {
        if (AttackDelayCorutine != null)
        {
            StopCoroutine(AttackDelayCorutine);
        }

        IsAttackCooldowned = true;
        IsAttackCanceled = false;
    }

    public abstract IEnumerator CalculatingAttackDelay();

    protected abstract void PerformAttack();
    protected abstract void PlayAttackAudio();
    //protected abstract void PlayAttackAnimation();
}