using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Legs : MonoBehaviour, ITorsoRotaionLimiter
{
    private Vector2 _direction;
    private float _minAngleRotation;
    private float _maxAngleRotation;
    private float _tresholdAngleCorrection;
    private float _minAngleClamp;
    private float _maxAngleClamp;


    private void Start()
    {
        _minAngleRotation = -90f;
        _maxAngleRotation = 90f;
        _tresholdAngleCorrection = 180f;
        _minAngleClamp = -75f;
        _maxAngleClamp = 75f;
    }

    private void Rotate()
    {
        if (_direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(-_direction.x, _direction.y) * Mathf.Rad2Deg;

            if (angle < _minAngleRotation || angle > _maxAngleRotation)
            {
                angle += _tresholdAngleCorrection;

            }
            else
            {
                angle = Mathf.Clamp(angle, _minAngleClamp, _maxAngleClamp);
            }

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Debug.DrawRay(transform.position, _direction, Color.yellow);
        }
    }

    public void CheckTorsoAngleLimit(Vector2 torsoAngle)
    {
        _direction = torsoAngle;

        Rotate();
    }
}