using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Laser : RangeCastWeapon
{
    [SerializeField] protected LineRenderer _lineRenderer;

    protected virtual void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = WeaponConfig.Sprite;

        //_lineRenderer = GetComponentInChildren<LineRenderer>();
        _lineRenderer.enabled = false;

        DetectionStratagy = new RaycastDetectionStratagy();
        DetectionStratagy.Init(WeaponConfig);
    }

    public override void Attack()
    {
        base.Attack();

        Crosshair.CalculateAttackRecoil(Random.Range(WeaponConfig.MinRecoil, WeaponConfig.MaxRecoil));
    }

    public override void Shoot(Vector2 aimPosition)
    {
        Vector2 aimDirection = GetNormolisedShotDirection(aimPosition);

        Vector2 spreadShotDirection = CalculateSpreadShotDirection(aimDirection,
            WeaponConfig.MinSpreadAngle, WeaponConfig.MaxSpreadAngle);

        Cast(spreadShotDirection);

        StartCoroutine(PlayShotEffect(spreadShotDirection));
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;
    }

    protected override void Cast(Vector2 spreadShotDirection)
    {
        DetectionStratagy.Cast(FireTrasform.position, spreadShotDirection);
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