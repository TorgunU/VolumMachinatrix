using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEnemy : Enemy
{
    protected float HealthBuff;

    protected override void Init()
    {
        base.Init();

        if(CreatureInitializeSO is TestEnemyConfig testEnemyInitializeSO)
        {
            HealthBuff = testEnemyInitializeSO.HealthBuff;

            Health += HealthBuff;
        }
    }

    public override void Die()
    {
        Debug.Log("Противник исчезает...");

        Destroy(gameObject);
    }

    public override bool IsHealthThresholdExceeded()
    {
        if(Health >= 0)
        {
            return false;
        }

        return true;
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage;
    }
}