using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private float _minRecoil;
    [SerializeField] private float _maxRecoil;
    [SerializeField] private float _minSpreadAngle;
    [SerializeField] private float _maxSpreadAngle;
    [SerializeField] private float _aimModifier;
    [SerializeField] private MagazineConfig _magazineConfig;

    public float MinRecoil { get => _minRecoil; protected set => _minRecoil = value; }
    public float MaxRecoil { get => _maxRecoil; protected set => _maxRecoil = value; }
    public float MinSpreadAngle { get => _minSpreadAngle; protected set => _minSpreadAngle = value; }
    public float MaxSpreadAngle { get => _maxSpreadAngle; protected set => _maxSpreadAngle = value; }
    public float AimModifier { get => _aimModifier; protected set => _aimModifier = value; }
    public MagazineConfig MagazineConfig { get => _magazineConfig; protected set => _magazineConfig = value; }
}
