using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    
    void Update()
    {
        transform.LookAt(new Vector3(_playerInput.Rotation.x, transform.position.y, _playerInput.Rotation.z));
    }
}
