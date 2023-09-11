using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletConfig : ScriptableObject
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _damageValue;
    [SerializeField] private float _speedShot;
    [SerializeField] private string _name;

    public float DamageValue { get => _damageValue; protected set => _damageValue = value; }
    public float SpeedShot { get => _speedShot; set => _speedShot = value; }
    public string Name { get => _name; protected set => _name = value; }
    public Bullet Bullet { get => _bullet; protected set => _bullet = value; }
}