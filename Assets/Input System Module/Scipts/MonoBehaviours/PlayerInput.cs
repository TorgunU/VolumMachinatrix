using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public abstract class PlayerInput : MonoBehaviour,
    IMovementDirection, IMovementStateEvents, 
    IAttackEvents, IAimingEvents, IReloadInputEvent,
    IInteractionEvent, IItemInteractionEvents,
    IInventoryManipulationEvents
{
    protected InputActions InputActions;
    protected Vector2 MovemenDirection;

    public abstract event Action AttackPressed;
    public abstract event Action<bool> RunStateChanged;
    public abstract event Action<bool> WalkStateChanged;
    public abstract event Action<Vector2> MovementDirectionUpdated;
    public abstract event Action<bool> AimHolded;
    public abstract event Action ReloadPressed;
    public abstract event Action Interacted;
    public abstract event Action PickupPressed;
    public abstract event Action UsePressed;
    public abstract event Action SwitchPressed;
    public abstract event Action InventoryItemSelected;
    public abstract event Action InventoryItemUnselected;

    //public abstract event Action<Vector2> LookDirectionUpdated;

    protected virtual void Awake()
    {
        InputActions = new InputActions();

        InputActions.KeyboardMouse.Move.performed += moveDirectionContext => 
        RaiseMovementDirection(moveDirectionContext);
        InputActions.KeyboardMouse.Move.canceled += moveDirectionContext => 
        RaiseMovementDirection(moveDirectionContext);

        InputActions.KeyboardMouse.Run.performed += runContext => 
        RaiseRunState(runContext);
        InputActions.KeyboardMouse.Run.canceled += runContext => 
        RaiseRunState(runContext);

        InputActions.KeyboardMouse.Attack.performed += attackContext => 
        RaiseAttackPressed(attackContext);

        InputActions.KeyboardMouse.Reload.performed += reloadContext =>
        RaiseReloadPressed(reloadContext);

        InputActions.KeyboardMouse.Aim.performed += aimContext => 
        RaiseAimHolded(aimContext);
        InputActions.KeyboardMouse.Aim.canceled += aimContext =>
        RaiseAimHolded(aimContext);

        InputActions.KeyboardMouse.Walk.performed += walkContext => 
        RaiseWalkState(walkContext);
        InputActions.KeyboardMouse.Walk.canceled += walkContext => 
        RaiseWalkState(walkContext);

        InputActions.KeyboardMouse.PickupItem.performed += pickupItemContext =>
        RaisePickupPressed(pickupItemContext);
        InputActions.KeyboardMouse.UseItem.performed += useItemContext =>
        RaiseUsePressed(useItemContext);
        InputActions.KeyboardMouse.SwitchItem.performed += switchItemContext =>
        RaiseSwitchPressed(switchItemContext);

        InputActions.KeyboardMouse.Interaction.performed += interactionContext =>
        RaiseInteractionPressed(interactionContext);

        InputActions.KeyboardMouse.FirstItemSlot.performed += firstItemSlotContext =>
        RaiseItemSelected(firstItemSlotContext);
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
    protected abstract void RaiseAimHolded(InputAction.CallbackContext aimContext);
    protected abstract void RaiseRunState(InputAction.CallbackContext runContext);
    protected abstract void RaiseWalkState(InputAction.CallbackContext walkContext);
    protected abstract void RaiseReloadPressed(InputAction.CallbackContext walkContext);
    protected abstract void RaiseInteractionPressed(InputAction.CallbackContext interactionContext);
    protected abstract void RaisePickupPressed(InputAction.CallbackContext pickupContext);
    protected abstract void RaiseUsePressed(InputAction.CallbackContext useContext);
    protected abstract void RaiseSwitchPressed(InputAction.CallbackContext switchContext);
    protected abstract void RaiseItemSelected(InputAction.CallbackContext selectContext);
    protected abstract void RaiseItemUnselected(InputAction.CallbackContext unselectContext);
}