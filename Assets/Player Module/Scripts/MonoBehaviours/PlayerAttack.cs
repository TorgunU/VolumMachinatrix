using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAttack : MonoBehaviour
{
    protected Weapon Weapon;

    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
    }

    public void Attack()
    {
        if (Weapon == null)
            return;

        Weapon.Attack();
    }
}