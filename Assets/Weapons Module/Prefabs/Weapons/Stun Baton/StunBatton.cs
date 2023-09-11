using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBatton : MeleeWeapon
{
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float AttackLength;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, AttackLength);
    }

    protected override void Hit(Vector2 aimPosition)
    {
        Vector2 attackDirection = (aimPosition - (Vector2)transform.position);

        Collider2D[] attackedColliders = Physics2D.OverlapAreaAll(
            (Vector2)transform.position, 
            attackDirection, 
            layerMask);

        foreach (Collider2D attackedCollider in attackedColliders)
        {
            if (attackedCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(WeaponConfig.DamageValue);
            }
        }
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);
    }

    protected override void PlayAttackAudio()
    {
        // declare a field and relaize range cast weapon

        throw new System.NotImplementedException();
    }
}