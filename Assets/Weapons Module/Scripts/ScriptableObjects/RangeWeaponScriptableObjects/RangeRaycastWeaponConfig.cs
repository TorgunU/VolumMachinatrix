using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/ New RangeRaycastWeaponConfig", order = 54)]
public class RangeRaycastWeaponConfig : WeaponConfig
{
    [SerializeField] private float shotLenght;

    // some shot effects fields

    public float ShotLenght { get => shotLenght; }
}
