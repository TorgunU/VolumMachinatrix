using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TestEnemyInitialize",
    menuName = "ScriptableObjects/CreatureInitializeSO/TestEnemyInitialize", order = 52)]
public class TestEnemyConfig : CreatureConfig
{
    [SerializeField] protected float healthBuff;

    public float HealthBuff { get => healthBuff; protected set => healthBuff = value; }
}
