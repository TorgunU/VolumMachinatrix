using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetectionStratagy : WeaponDetectionStratagy
{
    public override void Cast(Vector2 firePosition, Vector2 fireDirection)
    {
        RaycastHit2D[] raycastHittedArray = Physics2D.RaycastAll(firePosition, 
            fireDirection * WeaponConfig.ShotLenght);

        Debug.DrawRay(firePosition, fireDirection * WeaponConfig.ShotLenght, Color.red, 2);


        if (raycastHittedArray != null)
        {
            foreach (var hitted in raycastHittedArray)
            {
                if (hitted.collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(WeaponConfig.DamageValue);
                }
            }
        }
    }
}