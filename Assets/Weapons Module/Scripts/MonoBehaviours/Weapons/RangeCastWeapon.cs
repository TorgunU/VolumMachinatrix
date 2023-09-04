using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class RangeCastWeapon : RangeWeapon
{
    [SerializeField] protected RangeRaycastWeaponConfig WeaponConfig;

    protected WeaponCastStratagy CastStratagy;

    public override void PerformRangeAttack(Vector2 crosshairDirection)
    {
        Cast(crosshairDirection);

        StartCoroutine(PlayShotEffect(crosshairDirection));
    }

    protected override void IncreaseRecoilAttackToCrosshair()
    {
        Crosshair.IncreaseAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
    }

    protected abstract void Cast(Vector2 spreadShotDirection);
    protected abstract IEnumerator PlayShotEffect(Vector2 spreadShotDirection);

    public override RangeWeaponConfig RangeWeaponConfig => WeaponConfig;
}