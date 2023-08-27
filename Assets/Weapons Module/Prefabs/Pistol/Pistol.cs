using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangeBulletWeapon
{
    public override void Shoot()
    {
        PoolBullet();
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;
    }

    protected override void PoolBullet()
    {
        if(PoolBullets.TryGetElement(out Bullet bullet))
        {
            bullet.transform.position = FireTrasform.transform.position;
            bullet.transform.rotation = FireTrasform.transform.rotation;
            bullet.Fire();
        }
    }
}