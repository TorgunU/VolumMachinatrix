using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangeBulletWeapon
{
    public override void Shoot(Vector2 aimPosition)
    {
        if (TryPoolBullet(out Bullet bullet) == false)
        {
            return;
        }

        SetBulletShootTransform(bullet, aimPosition);

        bullet.Fire();
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;
    }

    protected override bool TryPoolBullet(out Bullet bullet)
    {
        return PoolBullets.TryGetElement(out bullet);
    }

    protected override void SetBulletShootTransform(Bullet bullet, Vector2 aimPosition)
    {
        Vector2 normalizedAimDirection = (aimPosition - (Vector2)FireTrasform.position).normalized;

        Vector2 spreadShotDirection = CalculateSpreadShotDirection(normalizedAimDirection);

        bullet.transform.position = FireTrasform.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, spreadShotDirection);

        Debug.DrawRay(FireTrasform.position, spreadShotDirection, Color.red, 5);

        bullet.SetDirection(spreadShotDirection);
    }

    protected override Vector2 CalculateSpreadShotDirection(Vector2 aimDirection)
    {
        float crosshairSize = (Crosshair.transform.localScale.x - Crosshair.MinScaleSize) /
            (Crosshair.MaxScaleSize - Crosshair.MinScaleSize);

        float maxSpreadAngle = Mathf.Lerp(MinSpreadAngle, MaxSpreadAngle, crosshairSize);

        float spreadOffset = Random.Range(-maxSpreadAngle, maxSpreadAngle);

        float spreadAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) *
            Mathf.Rad2Deg + spreadOffset;

        Vector2 spreadShotDirection = new Vector2(Mathf.Cos(spreadAngle * Mathf.Deg2Rad),
            Mathf.Sin(spreadAngle * Mathf.Deg2Rad)).normalized;

        return spreadShotDirection;
    }
}