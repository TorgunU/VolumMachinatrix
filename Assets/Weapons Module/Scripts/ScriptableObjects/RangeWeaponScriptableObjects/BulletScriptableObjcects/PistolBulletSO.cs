using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/BulletConfig/ New PistolBulletSO", order = 52)]
public class PistolBulletSO : BulletSO
{
    [SerializeField] private string _id;

    public string Id { get => _id; set => _id = value; }
}
