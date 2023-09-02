using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponConfig/ New RangeRaycastWeaponConfig", order = 54)]
public class RangeRaycastWeaponConfig : RangeWeaponConfig
{
    [SerializeField] private float shotLenght;

    public float ShotLenght { get => shotLenght; }
}
