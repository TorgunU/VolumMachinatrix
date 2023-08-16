using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInput : MonoBehaviour, 
    IMovementEvents, ILookDirectionSource, IAttackSource
{
    protected InputActions InputActions;
    protected Vector2 MovemenDirection;

    public abstract event Action<bool> OnAttackPressed;
    public abstract event Action<bool> RunStateChanged;
    public abstract event Action<bool> WalkStateChanged;
    public abstract event Action<Vector2> MovementDirectionUpdated;
    public abstract event Action<Vector2> LookDirectionUpdated;

    protected virtual void Awake()
    {
        InputActions = new InputActions();
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