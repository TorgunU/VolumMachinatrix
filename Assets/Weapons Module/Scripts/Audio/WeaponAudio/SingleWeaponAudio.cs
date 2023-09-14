using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWeaponAudio : WeaponAudio
{
    [SerializeField] protected RangeAttackAudio AttackAudio;

    private void Awake()
    {
        AttackAudio = GetComponentInChildren<RangeAttackAudio>();
    }

    private void Start()
    {
        AttackAudio.Init(AudioConfig.AudioSource);
    }

    public override void PlayAttack()
    {
        AttackAudio.Play();
    }
}
