using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletSO BulletConfig;

    protected abstract void OnCollisionEnter2D(Collision2D collision);
    protected abstract void Fire();
}
