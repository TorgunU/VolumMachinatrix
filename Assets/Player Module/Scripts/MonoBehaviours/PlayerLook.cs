using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CrossHair _crossHair;

    private ILookDirectionEvents _lookDirectionSource;
    private Vector2 _pointerPosiiton;

    public Vector2 PointerPosition { get => _pointerPosiiton; private set => _pointerPosiiton = value; }

    public void Init(ILookDirectionEvents lookDirectionSource)
    {
        _lookDirectionSource = lookDirectionSource;
        _lookDirectionSource.LookDirectionUpdated += OnPointerPositionUpdated;
    }

    private void OnDisable()
    {
        _lookDirectionSource.LookDirectionUpdated -= OnPointerPositionUpdated;
    }

    private void OnPointerPositionUpdated(Vector2 pointerPoisiton)
    {
        _pointerPosiiton = _camera.ScreenToWorldPoint(pointerPoisiton);

        _crossHair.GetPointerPosition(_pointerPosiiton);
    }
}