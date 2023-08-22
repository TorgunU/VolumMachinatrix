using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected BulletConfig BulletConfig;
    //[SerializeField] protected Bullet Bullet;
    [SerializeField] protected Transform BulletFireTransform;

    protected PoolBullet<Bullet> PoolBullets;

    protected virtual void Start()
    {
        IsAttackCooldowned = true;

        PoolBullets = new PoolBullet<Bullet>(BulletConfig.Bullet, BulletFireTransform,
            9, 18, true, 20);
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

    public abstract void Shoot();

    protected abstract void PoolBullet();
}