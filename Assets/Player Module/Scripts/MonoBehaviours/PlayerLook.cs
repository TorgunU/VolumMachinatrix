using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    ILookDirectionSource _lookDirectionSource;
    private Vector2 _mousePosition;

    public Vector2 MousePosition { get => _mousePosition; private set => _mousePosition = value; }

    public void Init(ILookDirectionSource lookDirectionSource)
    {
        _lookDirectionSource = lookDirectionSource;
    }

    private void OnEnable()
    {
        _lookDirectionSource.LookDirectionUpdated += OnPointerPositionUpdated;
    }

    private void OnDisable()
    {
        _lookDirectionSource.LookDirectionUpdated -= OnPointerPositionUpdated;
    }

    private void OnPointerPositionUpdated(Vector2 pointerPoisiton)
    {
        _mousePosition = _camera.ScreenToWorldPoint(pointerPoisiton);
    }
}