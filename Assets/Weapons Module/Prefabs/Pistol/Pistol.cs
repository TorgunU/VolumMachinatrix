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

        Vector2 aimDirection = GetNormolisedShotDirection(aimPosition);

        Vector2 spreadShotDirection = CalculateSpreadShotDirection(aimDirection,
            WeaponConfig.MinSpreadAngle, WeaponConfig.MaxSpreadAngle);

        SetBulletShootTransform(bullet, spreadShotDirection);

        bullet.Fire();
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        //PlayStateAnimation(IdleState);

        IsAttackCooldowned = true;
    }

    protected override bool TryPoolBullet(out Bullet bullet)
    {
        return PoolBullets.TryGetElement(out bullet);
    }

    protected override void SetBulletShootTransform(Bullet bullet, Vector2 spreadShotDirection)
    {
        bullet.transform.position = FireTrasform.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, spreadShotDirection);

        bullet.SetDirection(spreadShotDirection);
    }
}