using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBulletWeaponAudio : WeaponAudio
{
    [SerializeField] protected RangeWeaponAudioSO WeaponAudioSO;
    [SerializeField] protected PoolRangeWeaponAudio<RangeAttackAudioController> PoolAttackAudio;
    [SerializeField] private Transform HierarchyPoolAttackAudio;

    private void Start()
    {
        PoolAttackAudio = new PoolRangeWeaponAudio<RangeAttackAudioController>
            (WeaponAudioSO.RangeAttackAudioController, 5, 7, HierarchyPoolAttackAudio, true, 10);
    }

    public override void PlayAttack()
    {
        if (PoolAttackAudio.TryGetElement(out RangeAttackAudioController audioController) == false)
        {
            Debug.LogError("RangeAttackAudioController is null");
        }

        audioController.PlayAudioClip();
    }
}