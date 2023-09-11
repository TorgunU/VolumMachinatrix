using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New RangeRaycastWeaponConfig", order = 54)]
public class RangeRaycastWeaponConfig : RangeWeaponConfig
{
    [SerializeField] private float _shotLenght;

    public float ShotLenght { get => _shotLenght; protected set => _shotLenght = value; }
}
