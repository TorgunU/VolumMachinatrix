using System;
using UnityEngine;

[Serializable]
public class PlayerAttack : IAttackeable, IReloadable
{
    private PlayerWeapon _playerWeapon;

    public PlayerAttack()
    {
        _playerWeapon = new PlayerWeapon();
    }

    public void Attack()
    {
        if (_playerWeapon.CurrentWeapon == null)
            return;

        _playerWeapon.CurrentWeapon.Attack();
    }

    public void Reload()
    {
        if (_playerWeapon.CurrentWeapon == null) 
            return;

        if (_playerWeapon.CurrentWeapon is RangeWeapon rangeWeapon == false)
            return;

        rangeWeapon.Reload();
    }

    public PlayerWeapon PlayerWeapon { get => _playerWeapon; protected set => _playerWeapon = value; }
}