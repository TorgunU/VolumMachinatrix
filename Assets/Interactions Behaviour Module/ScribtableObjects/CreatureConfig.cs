using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreatureInitializeSO", order = 51)]
public abstract class CreatureConfig : ScriptableObject
{
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected float _health;

    public Sprite Sprite { get => _sprite; protected set => _sprite = value; }
    public float Health { get => _health; protected set => _health = value; }
}