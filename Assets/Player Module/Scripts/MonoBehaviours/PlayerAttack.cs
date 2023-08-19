using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    protected Weapon Weapon;

    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
    }

    public void TryAttack()
    {
        Weapon.Attack();
    }
}