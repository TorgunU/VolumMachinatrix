using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolBullet : Bullet
{
    public override event Action<Bullet> Collided;

    public override void Fire()
    {
        StartCoroutine(Flying());
    }

    public override void RevertFields()
    {
        transform.position = new Vector2(0,0);
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
        yield return new WaitWhile(() =>
        {
            Vector3 newPosition = transform.position + transform.up * (BulletConfig.SpeedShot * Time.deltaTime);
            transform.position = newPosition;

            return true;
        });
    }
}