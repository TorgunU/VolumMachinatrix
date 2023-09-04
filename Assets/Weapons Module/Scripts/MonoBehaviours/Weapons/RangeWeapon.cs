using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource), typeof(BoxCollider2D))]
public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected Transform FireTrasform;
    [SerializeField] protected CinemachineImpulseSource ImpulseSource;
    [SerializeField] private float _impulseForce = 5;
    [SerializeField] protected float AngleModifier;

    private Quaternion _defaultRotation = new Quaternion(0,0,0,0);
    private float _angle;

    protected Vector2 CalculateSpreadShotDirection(Vector2 aimDirection, float minSpreadAngle,
    float maxSpreadAngle)
    {
        float crosshairSize = (Crosshair.transform.localScale.x - Crosshair.MinScaleSize) /
            (Crosshair.MaxScaleSize - Crosshair.MinScaleSize);

        float spreadAngle = Mathf.Lerp(minSpreadAngle, maxSpreadAngle, crosshairSize);

        float spreadOffset = Random.Range(-spreadAngle, spreadAngle);

        float spreadOffsetAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) *
            Mathf.Rad2Deg + spreadOffset;
        _angle = spreadOffsetAngle;

        Vector2 spreadShotDirection = new Vector2(Mathf.Cos(spreadOffsetAngle * Mathf.Deg2Rad),
            Mathf.Sin(spreadOffsetAngle * Mathf.Deg2Rad)).normalized;

        Debug.DrawRay(transform.position, spreadShotDirection, Color.red, 3);

        return spreadShotDirection;
    }

    protected Vector2 GetNormolisedShotDirection(Vector2 crosshairPosition)
    {
        Vector2 aimDirection = (crosshairPosition - (Vector2)FireTrasform.position).normalized;

        return aimDirection;
    }

    protected void RecoilRotating(float angle, float angleModifier)
    {
        Quaternion quaternion = Quaternion.Euler(0f, 0f, angle + angleModifier);

        transform.rotation = quaternion;
    }

    protected void RotateToDefaultValues()
    {
        transform.rotation = _defaultRotation;
    }

    protected void GenereateShotRecoilEffect()
    {
        ImpulseSource.GenerateImpulse(_impulseForce);
    }

    protected override void PerformAttack()
    {
        Vector2 spreadShotDirection = GetSpreadShotDirection(Crosshair.transform.position);

        PerformRangeAttack(spreadShotDirection);

        RecoilRotating(_angle, AngleModifier);

        GenereateShotRecoilEffect();

        IncreaseRecoilAttackToCrosshair();
    }

    public abstract void PerformRangeAttack(Vector2 crosshairDirection);

    protected abstract Vector2 GetSpreadShotDirection(Vector2 crosshairPosition);
    protected abstract void IncreaseRecoilAttackToCrosshair();

    public abstract RangeWeaponConfig RangeWeaponConfig { get; }
}