using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon 
{
    private Weapon _currentWeapon;

    public void InjectWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
    }

    public Weapon CurrentWeapon { get => _currentWeapon; protected set => _currentWeapon = value; }
}
