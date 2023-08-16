using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInput : MonoBehaviour
{
    protected InputActions InputActions;

    protected InputActionReference AttackAction;


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
    public abstract bool IsChangeOnRun();
    public abstract bool IsChangedOnWalk();
}