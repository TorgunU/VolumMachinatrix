using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWeaponAudio : WeaponAudio
{
    public override void PlayAttack()
    {
        WeaponAudioConfig.WeaponAttackAudio.Play();
    }
}
