using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletConfig BulletConfig;
    [SerializeField] protected bool IsCollided = false;

    protected float ThresholdFlyingSecond;
    protected float Damage;
    protected Vector2 _direction;

    private void Awake()
    {
        ThresholdFlyingSecond = 15f;
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public void SetFlyDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public abstract void RevertFields();
    public virtual void FlyOut(float weaponDamage)
    {
        Damage = BulletConfig.DamageValue + weaponDamage;
    }

    public abstract event Action<Bullet> Collided;
}