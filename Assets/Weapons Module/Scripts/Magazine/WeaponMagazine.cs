using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponMagazine
{
    [SerializeField] protected int ShotCounter;

    public readonly int MagazineSize;

    private bool _isEmpty;

    public WeaponMagazine(int magazineSize)
    {
        IsEmpty = false;

        MagazineSize = magazineSize;
        ShotCounter = magazineSize;
    }

    public abstract void ReduceShots();
    public abstract void Reload();

    public bool IsEmpty { get => _isEmpty; protected set => _isEmpty = value; }
}