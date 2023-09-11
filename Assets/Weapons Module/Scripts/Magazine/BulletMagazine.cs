using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BulletMagazine : WeaponMagazine
{
    protected BulletConfig BulletConfig;
    protected PoolBullet<Bullet> PoolBullets;

    private Transform _hierarchyPool;

    public BulletMagazine(int magazineSize, BulletConfig bulletConfig, Transform hierarchyPool) : base(magazineSize)
    {
        BulletConfig = bulletConfig;
        _hierarchyPool = hierarchyPool;

        int minPoolSize = magazineSize / 2;

        PoolBullets = new PoolBullet<Bullet>(BulletConfig.Bullet, minPoolSize, MagazineSize, _hierarchyPool,
            true, 20);
    }

    public abstract bool TryGetBullet(out Bullet bullet);

    protected abstract Bullet PoolOut();
}