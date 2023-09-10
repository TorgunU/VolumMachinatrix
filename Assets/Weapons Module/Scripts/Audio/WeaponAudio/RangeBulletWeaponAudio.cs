using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBulletWeaponAudio : WeaponAudio
{
    [SerializeField] protected PoolRangeAttackAudio<RangeAttackAudio> PoolAttackAudio;

    [SerializeField] private Transform HierarchyPoolAttackAudio;


    private void Start()
    {
        PoolAttackAudio = new PoolRangeAttackAudio<RangeAttackAudio>
            ((RangeAttackAudio)WeaponAudioConfig.WeaponAttackAudio, 5, 7, HierarchyPoolAttackAudio, true, 10);
    }

    public override void PlayAttack()
    {
        if (PoolAttackAudio.TryGetElement(out RangeAttackAudio audioSource) == false)
        {
            Debug.LogError("RangeAttackAudio is null");
        }

        audioSource.Play();
    }
}