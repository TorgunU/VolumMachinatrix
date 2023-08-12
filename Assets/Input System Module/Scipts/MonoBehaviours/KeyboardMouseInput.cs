using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class KeyboardMouseInput : PlayerInput
{
    protected override void Awake()
    {
        base.Awake();

        //InputActions.KeyboardMouse.Move.performed += moveDirectionContext => GetMovementDirection();

        InputActions.KeyboardMouse.Move.performed += moveDirectionContext => GetMovementDirection();

        InputActions.KeyboardMouse.LookDirection.performed += lookDirectionContext => GetLookDireciton();

    }

    public override Vector2 GetLookDireciton()
    {
        return InputActions.KeyboardMouse.LookDirection.ReadValue<Vector2>();
    }

    public override Vector2 GetMovementDirection()
    {
        return InputActions.KeyboardMouse.Move.ReadValue<Vector2>();
    }

    protected override void RaiseChangedMovementDirection()
    {
        //OnMovementDirectionChanged.Invoke(InputActions.KeyboardMouse.Move.ReadValue<Vector2>());
    }
}