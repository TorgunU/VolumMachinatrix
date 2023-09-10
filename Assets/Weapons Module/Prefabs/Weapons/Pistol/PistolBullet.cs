using System;
using System.Collections;
using UnityEngine;

public class PistolBullet : Bullet
{
    private void Start()
    {
        ThresholdFlyingSecond = 15f;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(Damage);

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

    public override void FlyOut(float weaponDamage)
    {
        base.FlyOut(weaponDamage);

        StartCoroutine(Flying());
    }

    public override void RevertFields()
    {
        StopCoroutine(Flying());
    }

    public override event Action<Bullet> Collided;
}