using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangeWeapon
{
    public override void Shoot()
    {
        CreateBullet();
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;
    }

    private void CreateBullet()
    {
        Instantiate(BulletConfig.BulletPrefab, BulletFireTransform.position, BulletFireTransform.rotation);
    }
}