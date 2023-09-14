using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/WeaponAudioConfig/ New DefaultWeaponAudioConfig", order = 51)]
public class WeaponAudioConfig : ScriptableObject
{
    [SerializeField] private WeaponAttackAudio _attackAudio;
    [SerializeField] private AudioSource _audioSource;

    public WeaponAttackAudio AttackAudio { get => _attackAudio; }
    public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }
}