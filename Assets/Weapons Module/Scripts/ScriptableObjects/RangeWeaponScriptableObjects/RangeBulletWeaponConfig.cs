using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New Range Bullet Weapon Config", order = 54)]
public class RangeBulletWeaponConfig : WeaponConfig
{
    [SerializeField] private BulletConfig _bulletConfig;

    public BulletConfig BulletConfig { get => _bulletConfig; protected set => _bulletConfig = value; }
}