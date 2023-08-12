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
        InputActions.KeyboardMouse.Run.performed += runContext => IsChangeOnRun();
        InputActions.KeyboardMouse.Walk.performed += walkContext => IsChangedOnWalk();
    }

    public override Vector2 GetLookDireciton()
    {
        return InputActions.KeyboardMouse.LookDirection.ReadValue<Vector2>();
    }

    public override Vector2 GetMovementDirection()
    {
        return InputActions.KeyboardMouse.Move.ReadValue<Vector2>();
    }

    public override bool IsChangeOnRun()
    {
        return InputActions.KeyboardMouse.Run.IsPressed();
    }

    public override bool IsChangedOnWalk()
    {
        return InputActions.KeyboardMouse.Walk.IsPressed();
    }
}