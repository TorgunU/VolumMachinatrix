using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class RangeCastWeapon : RangeWeapon
{
    [SerializeField] protected RangeRaycastWeaponConfig WeaponConfig;

    protected WeaponDetectionStratagy DetectionStratagy;

    public abstract void Detect();
    protected abstract IEnumerator PlayShotEffect();
}