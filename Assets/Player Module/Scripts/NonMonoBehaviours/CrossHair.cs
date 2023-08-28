using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _thresholdDistance;
    [SerializeField] private float _minScaleSize;
    [SerializeField] private float _maxScaleSize;
    [SerializeField] private float _shrinkRate;
    [SerializeField] private float _expandRate;

    private float _distance;
    private float _previousDistance;

    private Vector2 _currentPosition;

    public float MinScaleSize { get => _minScaleSize; private set => _minScaleSize = value; }
    public float MaxScaleSize { get => _maxScaleSize; private set => _maxScaleSize = value; }

    private void Awake()
    {
        transform.localScale = new Vector3(_minScaleSize, _minScaleSize, 0);

        _distance = (_playerLook.PointerPosition - (Vector2)_playerPosition.position).magnitude;
        _previousDistance = _thresholdDistance;
    }

    private void Update()
    {
        MovePosition(_playerLook.PointerPosition);
        ChangeScaleFromDistance();
        _previousDistance = _distance;
    }

    public void MovePosition(Vector2 pointerPosition)
    {
        _currentPosition = pointerPosition;

        Vector2 directionToPointer = _currentPosition - (Vector2)_playerPosition.position;
        _distance = directionToPointer.magnitude;

        if(_distance < _thresholdDistance)
        {
            _currentPosition = (Vector2)_playerPosition.position + directionToPointer.normalized 
                * _thresholdDistance;
            transform.localScale = new Vector3(_minScaleSize, _minScaleSize, 0);

            _previousDistance = _distance;
        }

        transform.position = _currentPosition;
    }

    public void CalculateAttackRecoil(float attackRecoilRate)
    {
        float newScale = transform.localScale.x + (attackRecoilRate);

        if(newScale >= _maxScaleSize)
        {
            newScale = _maxScaleSize;
        }

        transform.localScale = new Vector3(newScale, newScale, 0);
    }

    private void ChangeScaleFromDistance()
    {
        float distanceChange = _distance - _previousDistance;

        if (distanceChange > 0.05f)
        {
            IncreaseScale();
        }
        else
        {
            ReduceScale();
        }
    }

    private void IncreaseScale()
    {
        if(transform.localScale.x >= _maxScaleSize)
        {
            return;
        }

        float newScale = transform.localScale.x + (_expandRate * Time.deltaTime);
        transform.localScale = new Vector3(newScale, newScale, 0);
    }

    private void ReduceScale()
    {
        if (transform.localScale.x <= _minScaleSize)
        {
            return;
        }

        float newScale = transform.localScale.x - _shrinkRate * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, 0);
    }
}