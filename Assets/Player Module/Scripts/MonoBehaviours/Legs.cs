using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Legs : MonoBehaviour, ILegRotaionLimiter
{
    [SerializeField] private float _rotationChangeInterval;

    private float _minAngleRotation;
    private float _maxAngleRotation;
    private float _tresholdAngleCorrection;
    private float _minAngleClamp;
    private float _maxAngleClamp;


    private void Start()
    {
        _rotationChangeInterval = 3f;

        _minAngleRotation = -90f;
        _maxAngleRotation = 90f;
        _tresholdAngleCorrection = 180f;
        _minAngleClamp = -75f;
        _maxAngleClamp = 75f;
    }

    public float GetCurrentRotationAngle()
    {
        return transform.rotation.eulerAngles.z;
    }

    public void Rotate(Vector2 inputDirection)
    {
        if (inputDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(-inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

            if (angle < _minAngleRotation || angle > _maxAngleRotation)
            {
                angle += _tresholdAngleCorrection;
            }
            else
            {
                angle = Mathf.Clamp(angle, _minAngleClamp, _maxAngleClamp);
            }

            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationChangeInterval);

            Debug.DrawRay(transform.position, inputDirection, Color.yellow);
        }
    }

    public float GetLegsRoationAngle()
    {
        return transform.rotation.eulerAngles.z;
    }
}