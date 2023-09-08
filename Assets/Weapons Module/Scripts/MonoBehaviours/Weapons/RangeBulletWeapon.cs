using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class RangeBulletWeapon : RangeWeapon
{
    [SerializeField] protected Transform BulletFireHierarchyPool;
    [SerializeField] protected RangeBulletWeaponConfig WeaponConfig;
    [SerializeField] protected RangeBulletWeaponAudio WeaponAudio;

    protected PoolBullet<Bullet> PoolBullets;
    protected Animator Animator;

    protected const string IdleState = "Idle";
    protected const string ShootState = "Shoot";

    protected void Awake()
    {
        Animator = GetComponent<Animator>();

        PoolBullets = new PoolBullet<Bullet>(WeaponConfig.BulletConfig.Bullet, 9, 18,
            BulletFireHierarchyPool, true, 20);

        WeaponSprite.SetSprite(WeaponConfig.Sprite);
    }

    protected override void PerformAttack()
    {
        base.PerformAttack();

        //PlayStateAnimation(ShootState);

        WeaponAudio.PlayAttack();
    }

    protected override void IncreaseRecoilAttackToCrosshair()
    {
        Crosshair.IncreaseAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
    }

    protected virtual void PlayStateAnimation(string stateAnimationName)
    {
        if (Animator == null)
        {
            Debug.LogWarning("Animator is null");
            return;
        }

        Animator.Play(stateAnimationName);
    }

    protected abstract bool TryPoolBullet(out Bullet bullet);
    protected abstract void ShootBullet(Bullet bullet);
    protected abstract void SetBulletShootTransform(Bullet bullet, Vector2 spreadShotDirection);

    public override RangeWeaponConfig RangeWeaponConfig => WeaponConfig;
}