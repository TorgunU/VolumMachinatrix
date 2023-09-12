using System.Collections;
using System.Linq.Expressions;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Laser : RangeCastWeapon
{
    [SerializeField] private LineRenderer _lineRenderer;

    private LaserMagazine Magazine;

    protected override void Awake()
    {
        base.Awake();

        _lineRenderer.enabled = false;

        CastStratagy = new RaycastDetectionStratagy();
        CastStratagy.Init(WeaponConfig);

        Magazine = new LaserMagazine(WeaponConfig.MagazineConfig.Capacity);
    }

    protected virtual void Start()
    {
        WeaponSprite.SetSprite(WeaponConfig.Sprite);
    }

    protected override void Cast(Vector2 spreadShotDirection)
    {
        Magazine.ReduceShots();

        CastStratagy.Cast(FireTrasform.position, spreadShotDirection);
    }

    protected override Vector2 GetSpreadShotDirection(Vector2 crosshairPosition)
    {
        Vector2 shotDirection = GetNormolisedShotDirection(crosshairPosition);

        Vector2 spreadShotDirection = CalculateSpreadShotDirection(shotDirection,
            WeaponConfig.MinSpreadAngle, WeaponConfig.MaxSpreadAngle);

        return spreadShotDirection;
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;

        RotateToDefaultValues();
    }

    protected override IEnumerator PlayShotEffect(Vector2 spreadShotDirection)
    {
        _lineRenderer.enabled = true;

        _lineRenderer.transform.rotation = transform.rotation;
        _lineRenderer.SetPosition(0, FireTrasform.position);
        _lineRenderer.SetPosition(1, FireTrasform.position + (Vector3)spreadShotDirection * WeaponConfig.ShotLenght);

        yield return new WaitForSeconds(0.02f);

        _lineRenderer.enabled = false;
    }

    public override void Reload()
    {
        WeaponMagazine.Reload();
    }

    public override WeaponMagazine WeaponMagazine
    {
        get { return Magazine; }
        protected set { Magazine = (LaserMagazine)value; }
    }
}