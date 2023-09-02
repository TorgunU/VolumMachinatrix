using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolBullet : Bullet
{
    public override event Action<Bullet> Collided;

    private void Start()
    {
        ThresholdFlyingSecond = 15f;
    }

    public override void Fire()
    {
        StartCoroutine(Flying());
    }

    public override void RevertFields()
    {
        StopCoroutine(Flying());
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(BulletConfig.DamageValue);

            Collided.Invoke(this);
        }
        else if (collision.collider.TryGetComponent(out LevelEnvironment levelEnvironment))
        {
            Collided.Invoke(this);
        }
    }

    private IEnumerator Flying()
    {
        float counter = 0;

        yield return new WaitWhile(() =>
        {
            Vector2 newPosition = (Vector2)transform.position + _direction 
            * (BulletConfig.SpeedShot * Time.deltaTime);

            transform.position = newPosition;

            counter += Time.deltaTime;

            return counter < ThresholdFlyingSecond;
        });

        Collided.Invoke(this);
    }
}