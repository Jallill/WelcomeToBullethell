using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    
    private void Awake()
    {
        _playerInput.JumpEventStarted += Jump;
        // _playerInput.JumpEventPerformed += Jump;
    }

    private void Jump()
    {
        //Read isGrounded
        if (_playerController.IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
        
    }
}
