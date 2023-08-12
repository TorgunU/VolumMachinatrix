using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerInput _playerInput;
    private Vector2 _mousePosition;

    public Vector2 MousePosition { get => _mousePosition; private set => _mousePosition = value; }

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        SetMousePosition();
    }

    private void SetMousePosition()
    {
        _mousePosition = _camera.ScreenToWorldPoint(_playerInput.GetLookDireciton());
    }
}