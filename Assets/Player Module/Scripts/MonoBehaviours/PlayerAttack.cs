using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private CinemachineImpulseSource _impulseSource;
    [SerializeField] private float _maxImpulse;

    protected Weapon Weapon;

    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
    }

    public void TryAttack()
    {
        if (Weapon == null)
            return;

        Weapon.Attack();
        //_impulseSource.GenerateImpulse(_maxImpulse);
    }
}