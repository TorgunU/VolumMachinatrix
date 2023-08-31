using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class RangeWeapon : Weapon, IWeaponShootable
{
    [SerializeField] protected Transform FireTrasform;
    [SerializeField] protected CinemachineImpulseSource _impulseSource;
    [SerializeField] private float _maxCameraImpulse = 5;

    public override void Attack()
    {
        if (IsAttackCooldowned == false)
        {
            return;
        }

        Shoot(Crosshair.transform.position);

        IsAttackCooldowned = false;

        _impulseSource.GenerateImpulse(_maxCameraImpulse);

        StartCoroutine(CalculatingAttackDelay());
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

        Vector2 spreadShotDirection = new Vector2(Mathf.Cos(spreadOffsetAngle * Mathf.Deg2Rad),
            Mathf.Sin(spreadOffsetAngle * Mathf.Deg2Rad)).normalized;

        Debug.DrawRay(transform.position, spreadShotDirection, Color.red, 3);

        return spreadShotDirection;
    }

    protected Vector2 GetNormolisedShotDirection(Vector2 aimPosition)
    {
        Vector2 aimDirection = (aimPosition - (Vector2)FireTrasform.position).normalized;

        return aimDirection;
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

    public abstract void Shoot(Vector2 aimPosition);
}
