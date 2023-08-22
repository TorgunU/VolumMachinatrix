using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New Range Weapon Config", order = 54)]
public class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private BulletConfig _bulletSO;

    public BulletConfig BulletSO { get => _bulletSO; protected set => _bulletSO = value; }
}