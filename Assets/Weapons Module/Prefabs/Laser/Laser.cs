using System.Collections;
using UnityEngine;

public class Laser : RangeCastWeapon
{
    [SerializeField] protected LineRenderer _lineRenderer;

    protected virtual void Awake()
    {
        WeaponSprite.SetSprite(WeaponConfig.Sprite);

        _lineRenderer.enabled = false;

        CastStratagy = new RaycastDetectionStratagy();
        CastStratagy.Init(WeaponConfig);
    }

    protected override void Cast(Vector2 spreadShotDirection)
    {
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
}