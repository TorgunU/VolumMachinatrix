using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/MagazineConfig/ New DefaultMagazineConfig", order = 51)]
public class MagazineConfig : ScriptableObject
{
    [SerializeField] int _capacity;

    public int Capacity { get => _capacity; set => _capacity = value; }
}
