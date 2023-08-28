using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New Range Bullet Weapon Config", order = 54)]
public class RangeBulletWeaponConfig : WeaponConfig
{
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private float _minRecoil;
    [SerializeField] private float _maxRecoil;

    public BulletConfig BulletConfig { get => _bulletConfig; protected set => _bulletConfig = value; }
    public float MinRecoil { get => _minRecoil; protected set => _minRecoil = value; }
    public float MaxRecoil { get => _maxRecoil; protected set => _maxRecoil = value; }
}