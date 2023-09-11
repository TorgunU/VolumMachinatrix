using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class RangeBulletWeapon : RangeWeapon
{
    [SerializeField] protected RangeBulletWeaponConfig WeaponConfig;
    [SerializeField] protected RangeBulletWeaponAudio WeaponAudio;
    [SerializeField] protected BulletMagazine Magazine;

    //protected Animator Animator;

    protected const string IdleState = "Idle";
    protected const string ShootState = "Shoot";

    protected void Awake()
    {
        //Animator = GetComponent<Animator>();

        WeaponSprite.SetSprite(WeaponConfig.Sprite);

        Magazine = new PistolMagazine(10, WeaponConfig.BulletConfig, HierarchyPoolBullet);
    }

    protected override void IncreaseRecoilAttackToCrosshair()
    {
        Crosshair.IncreaseAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
    }

    protected override void PlayAttackAudio()
    {
        WeaponAudio.PlayAttack();
    }

    public override void Reload()
    {
        // logic inventory

        Debug.Log("Reload");

        WeaponMagazine.Reload();
    }

    protected abstract void ShootBullet(Bullet bullet);
    protected abstract void SetBulletFlyTransofrm(Bullet bullet, Vector2 spreadShotDirection);

    public override RangeWeaponConfig RangeWeaponConfig
    {
        get { return WeaponConfig; }
        protected set { WeaponConfig = (RangeBulletWeaponConfig)value; }
    }
    public override WeaponMagazine WeaponMagazine
    {
        get { return Magazine; }
        protected set { Magazine = (BulletMagazine)value; }
    }
}