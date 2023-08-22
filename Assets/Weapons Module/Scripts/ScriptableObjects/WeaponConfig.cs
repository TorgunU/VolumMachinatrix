using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/ New WeaponConfig", order = 54)]
public abstract class WeaponConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _damageValue;
    [SerializeField] private float _attackFrequencyInSeconds;
    [SerializeField] private string _name;

    public Sprite Sprite { get => _sprite; protected set => _sprite = value; }
    public float DamageValue { get => _damageValue; protected set => _damageValue = value; }
    public string Name { get => _name; protected set => _name = value; }
    public float AttackFrequencyInSeconds { get => _attackFrequencyInSeconds; protected set => _attackFrequencyInSeconds = value; }
}