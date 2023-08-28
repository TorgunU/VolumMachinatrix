using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponAttackable
{
    [SerializeField] protected Transform WeaponPosition;
    [SerializeField] protected Crosshair Crosshair;

    protected SpriteRenderer SpriteRenderer;
    protected bool IsAttackCooldowned = true;

    public abstract void Attack();
    public abstract IEnumerator CalculatingAttackDelay();
}