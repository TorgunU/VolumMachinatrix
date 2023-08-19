using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New Range Weapon Config", order = 54)]
public class RangeWeaponSO : WeaponSO
{
    [SerializeField] private BulletSO _bulletSO;

    public BulletSO BulletSO { get => _bulletSO; protected set => _bulletSO = value; }
}