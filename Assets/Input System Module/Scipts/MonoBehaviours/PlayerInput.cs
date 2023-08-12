using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInput : MonoBehaviour
{
    //[SerializeField] protected Camera Camera;

    protected InputActions InputActions;

    public event Action<Vector2> OnMovementDirectionChanged;


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

    public abstract Vector2 GetMovementDirection();
    public abstract Vector2 GetLookDireciton();

    protected abstract void RaiseChangedMovementDirection();
}