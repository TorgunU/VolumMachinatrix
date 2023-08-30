using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected Transform FireTrasform;

    public override void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        Shoot(Crosshair.transform.position);

        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }

    protected Vector2 CalculateSpreadShotDirection(Vector2 aimDirection, float minSpreadAngle, 
        float maxSpreadAngle)
    {
        float crosshairSize = (Crosshair.transform.localScale.x - Crosshair.MinScaleSize) /
            (Crosshair.MaxScaleSize - Crosshair.MinScaleSize);

        float spreadAngle = Mathf.Lerp(minSpreadAngle, maxSpreadAngle, crosshairSize);

        float spreadOffset = Random.Range(-spreadAngle, spreadAngle);

        float spreadOffsetAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) *
            Mathf.Rad2Deg + spreadOffset;

        Vector2 spreadShotDirection = new Vector2(Mathf.Cos(spreadOffsetAngle * Mathf.Deg2Rad),
            Mathf.Sin(spreadOffsetAngle * Mathf.Deg2Rad)).normalized;

        return spreadShotDirection;
    }

    protected Vector2 GetNormolisedShotDirection(Vector2 aimPosition)
    {
        Vector2 aimDirection = (aimPosition - (Vector2)FireTrasform.position).normalized;

        return aimDirection;
    }

    public abstract void Shoot(Vector2 aimPosition);
}
