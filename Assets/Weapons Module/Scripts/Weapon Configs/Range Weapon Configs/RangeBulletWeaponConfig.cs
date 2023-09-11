using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/ RangeBulletWeaponConfig", order = 55)]
public class RangeBulletWeaponConfig : RangeWeaponConfig
{
    [SerializeField] private BulletConfig _bulletConfig;

    public BulletConfig BulletConfig { get => _bulletConfig; protected set => _bulletConfig = value; }
}