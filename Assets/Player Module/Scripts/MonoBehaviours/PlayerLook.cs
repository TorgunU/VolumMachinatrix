using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector2 _pointerPosition;

    public Vector2 PointerPosition { get => _pointerPosition; private set => _pointerPosition = value; }

    private void Update()
    {
        OnPointerPositionUpdated();
    }

    private void OnPointerPositionUpdated()
    {
        _pointerPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}