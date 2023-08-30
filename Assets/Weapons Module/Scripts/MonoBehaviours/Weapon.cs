using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Crosshair Crosshair;

    protected SpriteRenderer SpriteRenderer;
    protected Animator Animator;
    protected bool IsAttackCooldowned = true;

    protected const string IdleState = "Idle";
    protected const string ShootState = "Shoot";

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void Attack();
    public abstract IEnumerator CalculatingAttackDelay();

    protected void PlayStateAnimation(string stateAnimationName)
    {
        Animator.Play(stateAnimationName);
    }
}