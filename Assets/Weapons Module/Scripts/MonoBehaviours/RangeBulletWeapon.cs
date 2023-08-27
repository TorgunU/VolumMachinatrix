using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeBulletWeapon : RangeWeapon
{
    [SerializeField] protected RangeBulletWeaponConfig WeaponConfig;
    [SerializeField] protected Transform BulletFireHierarchyPool;

    protected PoolBullet<Bullet> PoolBullets;

    protected virtual void Start()
    {
        PoolBullets = new PoolBullet<Bullet>(WeaponConfig.BulletConfig.Bullet, 9, 18, 
            BulletFireHierarchyPool, true, 20);
    }

    public override void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        Shoot();

        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }

    protected abstract void PoolBullet();
}