using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInjector
{
    private PlayerAttack _playerAttack;
    private Crosshair _crosshair;
    private Transform _hierarchyPoolBullet;
    private PlayerRangeAiming _rangeAiming;

    public WeaponInjector(PlayerAttack playerAttack, 
        Crosshair crosshair, Transform hierarchyPoolBullet,
        PlayerRangeAiming rangeAiming)
    {
        _playerAttack = playerAttack;
        _crosshair = crosshair;
        _hierarchyPoolBullet = hierarchyPoolBullet;

        _rangeAiming = rangeAiming;
    }

    public void Init(Weapon weapon)
    {
        switch (weapon)
        {
            case RangeBulletWeapon rangeBulletWeapon:
                rangeBulletWeapon.Inject(_crosshair, _hierarchyPoolBullet);
                _rangeAiming.InjectRangeWeaponConfig(rangeBulletWeapon.RangeWeaponConfig);
                weapon = rangeBulletWeapon;
                break;
            default:

                Debug.LogError("Cant match weapon type");
                return;
        }

        _playerAttack.PlayerWeapon.InjectWeapon(weapon);
    }

}
