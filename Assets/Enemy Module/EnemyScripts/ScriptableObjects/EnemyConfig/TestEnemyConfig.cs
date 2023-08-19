using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureInitializeSO", 
    menuName = "CreatureInitializeSO/New TestEnemyInitialize", order = 54)]
public class TestEnemyConfig : CreatureConfig
{
    [SerializeField] protected float healthBuff;

    public float HealthBuff { get => healthBuff; protected set => healthBuff = value; }
}
