using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagazine
{
    protected BulletConfig BulletConfig;
    protected PoolBullet<Bullet> PoolBullets;

    private Transform _hierarchyPool;

    public BulletMagazine(BulletConfig bulletConfig, Transform hierarchyPool)
    {
        BulletConfig = bulletConfig;
        _hierarchyPool = hierarchyPool;

        PoolBullets = new PoolBullet<Bullet>(BulletConfig.Bullet, 9, 18, _hierarchyPool, true, 20);
    }

    public virtual Bullet GetBullet()
    {
        if(PoolBullets.TryGetElement(out Bullet bullet) == false)
        {
            Debug.LogError("Bullet was't pulled from object pool");
        }

        return bullet;
    }
}