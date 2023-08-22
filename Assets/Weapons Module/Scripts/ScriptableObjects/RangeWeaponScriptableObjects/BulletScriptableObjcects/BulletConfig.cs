using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/BulletConfig/ New BulletConfig", order = 51)]
public abstract class BulletConfig : ScriptableObject
{
    [SerializeField] private GameObject _bulletPrefab;
    //[SerializeField] private LayerMask _ingoredLayer;
    [SerializeField] private float _damageValue;
    [SerializeField] private float _speedShot;
    [SerializeField] private string _name;

    private Transform _fireTransform;

    public GameObject BulletPrefab { get => _bulletPrefab; protected set => _bulletPrefab = value; }
    public Transform FireTransform { get => _fireTransform; protected set => _fireTransform = value; }
    //public LayerMask IngoredLayer { get => _ingoredLayer; protected set => _ingoredLayer = value; }
    public float DamageValue { get => _damageValue; protected set => _damageValue = value; }
    public float SpeedShot { get => _speedShot; set => _speedShot = value; }
    public string Name { get => _name; protected set => _name = value; }
}