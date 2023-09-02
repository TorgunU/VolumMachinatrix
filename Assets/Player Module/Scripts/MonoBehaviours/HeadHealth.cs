using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _healthPoints;

    public void Die()
    {
        Debug.Log("Player's Die!");
    }

    public bool IsHealthThresholdExceeded()
    {
        return _healthPoints <= 0;
    }

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if(IsHealthThresholdExceeded())
        {
            Die();
        }
    }
}
