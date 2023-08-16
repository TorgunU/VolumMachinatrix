using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponentInChildren<PlayerMovement>();
    }

    private void Start()
    {
        _playerMovement.Init(_rigidbody2D, _playerInput);
    }


}
