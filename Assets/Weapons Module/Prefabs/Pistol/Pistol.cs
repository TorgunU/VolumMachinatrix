using System.Collections;
using UnityEngine;

public class Pistol : RangeBulletWeapon
{
    protected void Start()
    {
        AngleModifier = 90;
    }

    public override void PerformRangeAttack(Vector2 shotDirection)
    {
        if (TryPoolBullet(out Bullet bullet) == false)
        {
            throw new System.Exception("Bullet was't pulled from object pool");
        }

        SetBulletShootTransform(bullet, shotDirection);

        ShootBullet(bullet);
    }

    protected override void ShootBullet(Bullet bullet)
    {
        bullet.Fire();
    }

    protected override Vector2 GetSpreadShotDirection(Vector2 crosshairPosition)
    {
        Vector2 shotDirection = GetNormolisedShotDirection(crosshairPosition);

        Vector2 spreadShotDirection = CalculateSpreadShotDirection(shotDirection, 
            WeaponConfig.MinSpreadAngle, WeaponConfig.MaxSpreadAngle);

        return spreadShotDirection;
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;

        RotateToDefaultValues();
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