using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMagazine : BulletMagazine
{

    public PistolMagazine(int magazineSize, BulletConfig bulletConfig, Transform hierarchyPool) :
        base(magazineSize, bulletConfig, hierarchyPool)
    { }

    public override void Reload()
    {
        ShotCounter = MagazineSize;
    }

    public override bool TryGetBullet(out Bullet bullet)
    {
        if(IsEmpty)
        {
            bullet = null;
            return false;
        }

        ReduceShots();

        bullet = PoolOut();
        return true;
    }

    public override void ReduceShots()
    {
        ShotCounter--;

        if (ShotCounter == 0)
        {
            IsEmpty = true;
            return;
        }
    }

    protected override Bullet PoolOut()
    {
        if (PoolBullets.TryGetElement(out Bullet bullet) == false)
        {
            Debug.LogError("Bullet was't pulled from object pool");
        }

        return bullet;
    }
}
