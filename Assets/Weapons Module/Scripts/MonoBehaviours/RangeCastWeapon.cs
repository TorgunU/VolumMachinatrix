using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class RangeCastWeapon : RangeWeapon
{
    [SerializeField] protected RangeRaycastWeaponConfig WeaponConfig;

    protected WeaponDetectionStratagy DetectionStratagy;

    protected abstract void Cast(Vector2 spreadShotDirection);
    protected abstract IEnumerator PlayShotEffect();
}