using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public sealed class KeyboardMouseInput : PlayerInput
{
    public override event Action AttackPressed;
    public override event Action<bool> RunStateChanged;
    public override event Action<bool> WalkStateChanged;
    public override event Action<Vector2> MovementDirectionUpdated;
    public override event Action<bool> AimHolded;
    public override event Action ReloadPressed;
    //public override event Action<Vector2> LookDirectionUpdated;

    protected override void RaiseMovementDirection(InputAction.CallbackContext movementContext)
    {
        MovemenDirection = movementContext.action.ReadValue<Vector2>();

        if (movementContext.performed)
        {
            MovementDirectionUpdated?.Invoke(MovemenDirection);
        }
        else if (movementContext.canceled)
        {
            MovementDirectionUpdated?.Invoke(Vector2.zero);
        }
    }

    protected override void RaiseAttackPressed(InputAction.CallbackContext attackContext)
    {
        if (attackContext.performed)
        {
            AttackPressed?.Invoke();
        }
    }

    protected override void RaiseReloadPressed(InputAction.CallbackContext reloadContext)
    {
        if (reloadContext.performed)
        {
            ReloadPressed?.Invoke();
        }
    }

    protected override void RaiseAimHolded(InputAction.CallbackContext aimContext)
    {
        AimHolded?.Invoke(aimContext.action.IsPressed());
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