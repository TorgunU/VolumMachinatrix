using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class Player : MonoBehaviour, IAttackeable
{
    private IMovementEvents _movementsInput;
    private ILookDirectionEvents _lookDirectionInput;
    private IAttackEvents _attacksInput;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _movement;
    private PlayerLook _look;
    private PlayerAttack _attack;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementsInput = GetComponent<PlayerInput>();
        _lookDirectionInput = GetComponent<PlayerInput>();
        _attacksInput = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        _attack = GetComponent<PlayerAttack>();

        _look = GetComponentInChildren<PlayerLook>();

        _movement.Init(_rigidbody2D, _movementsInput);
        _look.Init(_lookDirectionInput);

        _attacksInput.AttackPressed += Attack;
    }

    public void Attack()
    {
        _attack.TryAttack();
    }


}