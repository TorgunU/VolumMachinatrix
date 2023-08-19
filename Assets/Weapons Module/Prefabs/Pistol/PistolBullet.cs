using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolBullet : Bullet
{
    private void Start()
    {
        Fire();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable;

        //if (collision.collider.gameObject.layer != BulletConfig.IngoredLayer)
        //{
        if (collision.collider.TryGetComponent(out damageable))
        {
            damageable.TakeDamage(BulletConfig.DamageValue);
            Destroy(gameObject);
        }
        else if (collision.collider.TryGetComponent(out LevelEnvironment levelBorder))
        {
            Destroy(gameObject);
        }
    }

    protected override void Fire()
    {
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        yield return new WaitWhile(() =>
        {

            Vector3 newPosition = transform.position + transform.up * (BulletConfig.SpeedShot * Time.deltaTime);
            transform.position = newPosition;

            return gameObject != null;
        });
    }
}