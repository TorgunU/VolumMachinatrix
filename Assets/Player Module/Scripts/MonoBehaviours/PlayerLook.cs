using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _mousePosition;
    private float _minAngle;
    private float _maxAngle;
    private float _previousClampedAngle;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();

        _minAngle = -75f;
        _maxAngle = 75f;
    }

    private void FixedUpdate()
    {
        SetMousePosition();
        FaceOnMousePointer();
    }

    private void FaceOnMousePointer()
    {
        float angle = CalculateAngle();

        if (CheckAngleOnThresholds(ref angle) == false)
        {
            return;
        }

        _rigidbody2D.MoveRotation(angle);
    }

    private void SetMousePosition()
    {
        _mousePosition = _camera.ScreenToWorldPoint(_playerInput.GetLookDireciton());
    }

    private float CalculateAngle()
    {
        Vector2 tranformPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 facindDirection = _mousePosition - tranformPosition;

        float angle = Mathf.Atan2(-facindDirection.x, facindDirection.y) * Mathf.Rad2Deg;
        return angle;
    }

    private bool CheckAngleOnThresholds(ref float angle)
    {
        if (angle != _previousClampedAngle &&
            (angle < _minAngle || angle > _maxAngle))
        {
            angle = Mathf.Clamp(angle, _minAngle, _maxAngle);
            _previousClampedAngle = angle;
        }
        else if (angle == _previousClampedAngle)
        {
            return false;
        }

        return true;
    }
}