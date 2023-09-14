using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Legs : MonoBehaviour
{
    [SerializeField] private float _rotationChangeInterval;

    private void Start()
    {
        _rotationChangeInterval = 3f;
    }

    public void Rotate(float angle)
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationChangeInterval);
    }
}