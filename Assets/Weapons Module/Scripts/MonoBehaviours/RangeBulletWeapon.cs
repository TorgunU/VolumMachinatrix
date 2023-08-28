using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeBulletWeapon : RangeWeapon
{
    [SerializeField] protected Transform BulletFireHierarchyPool;
    [SerializeField] protected RangeBulletWeaponConfig WeaponConfig;
    [SerializeField] protected float MinSpreadAngle = 0f;
    [SerializeField] protected float MaxSpreadAngle = 30f;

    protected PoolBullet<Bullet> PoolBullets;

    protected virtual void Start()
    {
        PoolBullets = new PoolBullet<Bullet>(WeaponConfig.BulletConfig.Bullet, 9, 18,
            BulletFireHierarchyPool, true, 20);
    }

    public override void Attack()
    {
        base.Attack();

        Debug.Log("Calculate recoil attack");
        Crosshair.CalculateAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
    }

    protected abstract bool TryPoolBullet(out Bullet bullet);
    protected abstract void SetBulletShootTransform(Bullet bullet, Vector2 aimPosition);
    protected abstract Vector2 CalculateSpreadShotDirection(Vector2 aimDirection);
}