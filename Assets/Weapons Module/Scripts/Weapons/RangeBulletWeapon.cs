using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class RangeBulletWeapon : RangeWeapon
{
    [SerializeField] protected RangeBulletWeaponConfig WeaponConfig;
    [SerializeField] protected BulletMagazine Magazine;

    [SerializeField] protected Transform HierarchyPoolBullet;

    protected const string IdleState = "Idle";
    protected const string ShootState = "Shoot";

    protected override void Awake()
    {
        base.Awake();

        Magazine = new PistolMagazine(
            WeaponConfig.MagazineConfig.Capacity,
            WeaponConfig.BulletConfig,
            HierarchyPoolBullet);
    }

    public void Inject(Crosshair crosshair, Transform hierarchyPoolBullet)
    {
        Crosshair = crosshair;

        HierarchyPoolBullet.SetParent(hierarchyPoolBullet);
    }

    protected virtual void Start()
    {
        WeaponSprite.SetSprite(WeaponConfig.Sprite);
    }

    protected override void IncreaseRecoilAttackToCrosshair()
    {
        Crosshair.IncreaseAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
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

    //protected Transform HierarchyPoolBullet { get => _hierarchyPoolBullet; protected set => _hierarchyPoolBullet}
}