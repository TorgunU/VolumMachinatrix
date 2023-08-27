using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    [SerializeField] private float _thresholdDistance;
    [SerializeField] private float _minScaleSize;
    [SerializeField] private float _maxScaleSize;
    [SerializeField] private float _shrinkRate;
    [SerializeField] private float _expandRate;

    private Vector2 _pointerPosition;
    private float _previousDistance;

    private void Update()
    {
        MovePosition();
    }

    public void GetPointerPosition(Vector2 pointerPosition)
    {
        _pointerPosition = pointerPosition;
    }

    public void MovePosition()
    {
        Vector2 directionToPointer = _pointerPosition - (Vector2)_playerPosition.position;
        float distanceToPointer = directionToPointer.magnitude;

        if(distanceToPointer < _thresholdDistance)
        {
            _pointerPosition = (Vector2)_playerPosition.position + directionToPointer.normalized 
                * _thresholdDistance;
        }

        float newScale;
        if (distanceToPointer > _previousDistance)
        {
            newScale = Mathf.MoveTowards(transform.localScale.x, _maxScaleSize, Time.deltaTime * _expandRate);
        }
        else
        {
            newScale = Mathf.MoveTowards(transform.localScale.x, _minScaleSize, Time.deltaTime * _shrinkRate / 2);
        }

        transform.localScale = new Vector3(newScale, newScale, 0);
        _previousDistance = distanceToPointer;

        transform.position = _pointerPosition;
    }
}