using System.Collections;
using UnityEngine;

public class Pistol : RangeBulletWeapon
{
    protected override void Start()
    {
        base.Start();

        WeaponSprite.AngleRotationModifier = -90;

        //BulletMagazine = new PistolMagazine(10, WeaponConfig.BulletConfig, HierarchyPoolBullet);
    }

    public override void PerformRangeAttack(Vector2 shotDirection)
    {
        if(Magazine.TryGetBullet(out Bullet bullet) == false)
        {
            IsAttackCanceled = true;

            Debug.LogWarning("Bullet wasn't pooled");

            return;
        }

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