using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class Player : MonoBehaviour
{
    private IMovementEvents _movementsInput;
    private ILookDirectionSource _lookDirectionInput;
    private IAttackSource _attacksInput;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _playerMovement;
    private PlayerLook _playerLook;

    private void Awake()
    {
        _movementsInput = GetComponent<PlayerInput>();
        _lookDirectionInput = GetComponent<PlayerInput>();
        _attacksInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();

        _playerLook = GetComponentInChildren<PlayerLook>();

        _playerMovement.Init(_rigidbody2D, _movementsInput);
        _playerLook.Init(_lookDirectionInput);

        _attacksInput.AttackPressed += OutputAttackMessage;
    }

    private void OutputAttackMessage(bool isAttack)
    {
        if(isAttack)
        {
            Debug.Log("Attack!!!");
        }
    }
}