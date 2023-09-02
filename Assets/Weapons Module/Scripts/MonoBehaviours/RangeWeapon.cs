using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource), typeof(BoxCollider2D))]
public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected Transform FireTrasform;
    [SerializeField] protected CinemachineImpulseSource _impulseSource;

    [SerializeField] private float _impulseForce = 5;

    private Coroutine _recoilRotatingCorutine;
    private Quaternion _defaultRotation;
    private float _angle;

    private void Start()
    {
        _defaultRotation = transform.rotation;
    }

    public abstract void PerformRangeAttack(Vector2 crosshairDirection);
    protected abstract Vector2 GetSpreadShotDirection(Vector2 crosshairPosition);
    protected abstract void IncreaseRecoilAttackToCrosshair();

    public override void PerformAttack()
    {
        Vector2 spreadShotDirection = GetSpreadShotDirection(Crosshair.transform.position);

        PerformRangeAttack(spreadShotDirection);

        _recoilRotatingCorutine = StartCoroutine(RecoilRotating(_angle));

        GenereateShotRecoilEffect();

        IncreaseRecoilAttackToCrosshair();
    }

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

    protected IEnumerator RecoilRotating(float angle)
    {
        Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);

        Debug.Log(angle);

        transform.rotation = quaternion;

        yield return null;
    }

    protected IEnumerator RecoilRotating(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        targetAngle -= 90;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            targetAngle);

        yield return null;
    }

    protected void RotateToDefaultValues()
    {
        transform.rotation = _defaultRotation;
    }

    protected void GenereateShotRecoilEffect()
    {
        _impulseSource.GenerateImpulse(_impulseForce);
    }
}