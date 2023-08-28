using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public override void Shoot(Vector2 aimDirection)
    {
        Detect();
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(WeaponConfig.AttackFrequencyInSeconds);

        IsAttackCooldowned = true;
    }

    public override void Detect()
    {
        DetectionStratagy.Cast(FireTrasform.position, FireTrasform.up);

        StartCoroutine(PlayShotEffect());
    }

    protected override IEnumerator PlayShotEffect()
    {
        _lineRenderer.enabled = true;

        _lineRenderer.transform.rotation = transform.rotation;
        _lineRenderer.SetPosition(0, FireTrasform.position);
        _lineRenderer.SetPosition(1, FireTrasform.position + FireTrasform.up * WeaponConfig.ShotLenght);

        yield return new WaitForSeconds(0.02f);

        _lineRenderer.enabled = false;
    }
}