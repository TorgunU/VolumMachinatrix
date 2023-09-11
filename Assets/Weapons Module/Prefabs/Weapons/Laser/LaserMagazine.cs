using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMagazine : WeaponMagazine
{
    public LaserMagazine(int magazineSize) : base(magazineSize)
    {
    }

    public override void Reload()
    {
        ShotCounter = MagazineSize;
    }

    public override void ReduceShots()
    {
        ShotCounter--;

        if (ShotCounter == 0)
        {
            IsEmpty = true;
        }
    }

}