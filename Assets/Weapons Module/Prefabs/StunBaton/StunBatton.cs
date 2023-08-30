using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBatton : MeleeWeapon
{
    [SerializeField] private float attackLength;
    [SerializeField] protected LayerMask layerMask;

    protected override void Hit(Vector2 aimPosition)
    {
        Vector2 attackDirection = (aimPosition - (Vector2)transform.position);

        //Collider2D[] attackedColliders = Physics2D.OverlapCircleAll(transform.position, attackLength);

        Collider2D[] attackedColliders = Physics2D.OverlapAreaAll((Vector2)transform.position, attackDirection, layerMask);

        foreach (Collider2D attackedCollider in attackedColliders)
        {
            //if (((1 << attackedCollider.gameObject.layer) & layerMask) == 0)
            //{
                if (attackedCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(WeaponConfig.DamageValue);
                }
            //}
        }
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, attackLength);
    }
}