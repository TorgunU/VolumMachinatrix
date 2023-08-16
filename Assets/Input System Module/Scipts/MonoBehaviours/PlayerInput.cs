using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInput : MonoBehaviour, 
    IMovementEvents, ILookDirectionSource, IAttackSource
{
    protected InputActions InputActions;
    protected Vector2 MovemenDirection;

    public abstract event Action<bool> AttackPressed;
    public abstract event Action<bool> RunStateChanged;
    public abstract event Action<bool> WalkStateChanged;
    public abstract event Action<Vector2> MovementDirectionUpdated;
    public abstract event Action<Vector2> LookDirectionUpdated;

    protected virtual void Awake()
    {
        InputActions = new InputActions();

        InputActions.KeyboardMouse.Move.performed += moveDirectionContext => RaiseMovementDirection(moveDirectionContext);
        InputActions.KeyboardMouse.Move.canceled += moveDirectionContext => RaiseMovementDirection(moveDirectionContext);

        InputActions.KeyboardMouse.LookDirection.performed += lookDirectionContext => RaiseLookDireciton(lookDirectionContext);

        InputActions.KeyboardMouse.Run.performed += runContext => RaiseRunState(runContext);
        InputActions.KeyboardMouse.Run.canceled += runContext => RaiseRunState(runContext);

        InputActions.KeyboardMouse.Attack.performed += attackContext => RaiseAttackPressed(attackContext);

        InputActions.KeyboardMouse.Walk.performed += walkContext => RaiseWalkState(walkContext);
        InputActions.KeyboardMouse.Walk.canceled += walkContext => RaiseWalkState(walkContext);
    }

    protected virtual void OnEnable()
    {
        InputActions.Enable();
    }

    protected virtual void OnDisable()
    {
        InputActions.Disable();
    }

    protected abstract void RaiseAttackPressed(InputAction.CallbackContext attackContext);
    protected abstract void RaiseMovementDirection(InputAction.CallbackContext movementcontext);
    protected abstract void RaiseLookDireciton(InputAction.CallbackContext lookDirectiontContext);
    protected abstract void RaiseRunState(InputAction.CallbackContext runContext);
    protected abstract void RaiseWalkState(InputAction.CallbackContext walkContext);
}