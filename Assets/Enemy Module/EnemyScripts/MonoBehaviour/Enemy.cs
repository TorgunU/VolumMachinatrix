using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable 
{
    [SerializeField] protected float Health;
    [SerializeField] protected CreatureConfig CreatureInitializeSO;

    protected SpriteRenderer _spriteRenderer;
    protected Sprite _sprite;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _sprite = CreatureInitializeSO.Sprite;
        _spriteRenderer.sprite = _sprite;

        Health = CreatureInitializeSO.Health;
    }

    public abstract void Die();
    public abstract bool IsHealthTresholdExceeded();
    public abstract void TakeDamage(float damage);
}