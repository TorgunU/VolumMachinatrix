using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private float _minRecoil;
    [SerializeField] private float _maxRecoil;
    [SerializeField] private float _minSpreadAngle;
    [SerializeField] private float _maxSpreadAngle;

    public float MinRecoil { get => _minRecoil; protected set => _minRecoil = value; }
    public float MaxRecoil { get => _maxRecoil; protected set => _maxRecoil = value; }
    public float MinSpreadAngle { get => _minSpreadAngle; protected set => _minSpreadAngle = value; }
    public float MaxSpreadAngle { get => _maxSpreadAngle; protected set => _maxSpreadAngle = value; }
}
