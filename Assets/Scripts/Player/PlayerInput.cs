using System;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void InputEventHandler();

public class PlayerInput : MonoBehaviour
{
    public event InputEventHandler FireEventStarted;
    public event InputEventHandler FireEventPerformed;
    public event InputEventHandler FireEventCancled;
    private bool _firePerformed;
    private Vector2 _movement;
    public bool FirePerformed => _firePerformed;
    public Vector2 Movement => _movement;

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            FireEventStarted?.Invoke();
            _firePerformed = true;
        }
        else if (context.performed)
        {
            FireEventPerformed?.Invoke();
            _firePerformed = true;
        }
        else if(context.canceled)
        {
            FireEventCancled?.Invoke();
            _firePerformed = false;
        }
    }
}
