using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable 
{
    [SerializeField] protected float Health;
    [SerializeField] protected CreatureConfig CreatureInitializeSO;

    protected SpriteRenderer _spriteRenderer;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = CreatureInitializeSO.Sprite;

        Health = CreatureInitializeSO.Health;
    }

    public abstract void Die();
    public abstract bool IsHealthTresholdExceeded();
    public abstract void TakeDamage(float damage);
}