using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/WeaponAudioSO/RangeWeaponAudioSO", order = 51)]
public class RangeWeaponAudioSO : ScriptableObject
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private RangeAttackAudioController _rangeAttackAudioController;

    public RangeAttackAudioController RangeAttackAudioController { get => _rangeAttackAudioController; }
    public AudioMixerGroup AudioMixerGroup { get => _audioMixerGroup; set => _audioMixerGroup = value; }
}