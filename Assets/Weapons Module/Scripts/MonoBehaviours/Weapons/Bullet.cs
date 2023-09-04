using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletConfig BulletConfig;
    [SerializeField] protected bool IsCollided = false;

    protected float ThresholdFlyingSecond;
    protected Vector2 _direction;

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public abstract void RevertFields();
    public abstract void Fire();


    public abstract event Action<Bullet> Collided;
}