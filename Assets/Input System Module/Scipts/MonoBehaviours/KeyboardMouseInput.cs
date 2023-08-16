using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class KeyboardMouseInput : PlayerInput
{
    public override event Action<bool> OnAttackPressed;
    public override event Action<bool> RunStateChanged;
    public override event Action<bool> WalkStateChanged;
    public override event Action<Vector2> MovementDirectionUpdated;
    public override event Action<Vector2> LookDirectionUpdated;

    protected override void Awake()
    {
        base.Awake();

        InputActions.KeyboardMouse.Attack.performed += attackContext => RaiseAttackPressed(attackContext);
        InputActions.KeyboardMouse.Move.performed += moveDirectionContext => RaiseMovementDirection(moveDirectionContext);
        InputActions.KeyboardMouse.LookDirection.performed += lookDirectionContext => RaiseLookDireciton(lookDirectionContext);
        InputActions.KeyboardMouse.Run.performed += runContext => RaiseRunState(runContext);
        InputActions.KeyboardMouse.Walk.performed += walkContext => RaiseWalkState(walkContext);


        InputActions.KeyboardMouse.Move.canceled += s => StopMove(s);
    }

    private void StopMove(InputAction.CallbackContext movementcontext)
    {

        if (movementcontext.canceled)
        {
            MovementDirectionUpdated?.Invoke(Vector2.zero);
        }

    }

    protected override void RaiseMovementDirection(InputAction.CallbackContext movementcontext)
    {
        MovemenDirection = movementcontext.action.ReadValue<Vector2>();

        if (movementcontext.performed)
        {
            MovementDirectionUpdated?.Invoke(MovemenDirection);
        }
    }

    protected override void RaiseAttackPressed(InputAction.CallbackContext attackContext)
    {
        OnAttackPressed?.Invoke(attackContext.action.IsPressed());
    }

    protected override void RaiseLookDireciton(InputAction.CallbackContext lookDirectiontContext)
    {
        LookDirectionUpdated?.Invoke(lookDirectiontContext.action.ReadValue<Vector2>());
    }

    protected override void RaiseRunState(InputAction.CallbackContext runContext)
    {
        RunStateChanged?.Invoke(runContext.action.IsPressed());
    }

    protected override void RaiseWalkState(InputAction.CallbackContext walkContext)
    {
        WalkStateChanged?.Invoke(walkContext.action.IsPressed());
    }
}