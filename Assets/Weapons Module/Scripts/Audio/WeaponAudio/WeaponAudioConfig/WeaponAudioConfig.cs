using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/WeaponAudioConfig/ New DefaultWeaponAudioConfig", order = 51)]
public class WeaponAudioConfig : ScriptableObject
{
    [SerializeField] private WeaponAttackAudio _weaponAttackAudio;

    public WeaponAttackAudio WeaponAttackAudio { get => _weaponAttackAudio; }
}