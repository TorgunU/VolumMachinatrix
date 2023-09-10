using System.Collections;
using UnityEngine;

public class Pistol : RangeBulletWeapon
{
    protected void Start()
    {
        WeaponSprite.AngleRotationModifier = -90;
    }

    public override void PerformRangeAttack(Vector2 shotDirection)
    {
        Bullet bullet = BulletMagazine.GetBullet();

        SetBulletFlyTransofrm(bullet, shotDirection);

        ShootBullet(bullet);
    }

    protected override void ShootBullet(Bullet bullet)
    {
        bullet.FlyOut(WeaponConfig.DamageValue);
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

    protected override void SetBulletFlyTransofrm(Bullet bullet, Vector2 spreadShotDirection)
    {
        bullet.transform.position = FireTrasform.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, spreadShotDirection);

        bullet.SetFlyDirection(spreadShotDirection);
    }
}