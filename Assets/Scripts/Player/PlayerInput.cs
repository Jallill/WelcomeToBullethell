using System;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void InputEventHandler();

public class PlayerInput : MonoBehaviour
{
    private bool _primaryFirePerformed;
    private bool _secondaryFirePerformed;
    private bool _jumpPerformed;
    private Vector2 _movement;
    private Vector2 _rotation;
    
    public event InputEventHandler PrimaryFireEventStarted;
    public event InputEventHandler PrimaryFireEventPerformed;
    public event InputEventHandler PrimaryFireEventCanceled;
    
    public event InputEventHandler SecondaryFireEventStarted;
    public event InputEventHandler SecondaryFireEventPerformed;
    public event InputEventHandler SecondaryFireEventCanceled;

    public event InputEventHandler JumpEventStarted;
    public event InputEventHandler JumpEventPerformed;
    public event InputEventHandler JumpEventCanceled;
    
    public bool PrimaryFirePerformed => _primaryFirePerformed;
    public bool SecondaryFirePerformed => _secondaryFirePerformed;
    public bool JumpPerformed => _jumpPerformed;
    public Vector2 Movement => _movement;
    public Vector2 Rotation => _rotation;

    public void Look(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    public void PrimaryFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PrimaryFireEventStarted?.Invoke();
            _primaryFirePerformed = true;
        }
        else if (context.performed)
        {
            PrimaryFireEventPerformed?.Invoke();
            _primaryFirePerformed = true;
        }
        else if(context.canceled)
        {
            PrimaryFireEventCanceled?.Invoke();
            _primaryFirePerformed = false;
        }
    }

    public void SecondaryFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SecondaryFireEventStarted?.Invoke();
            _secondaryFirePerformed = true;
        }
        else if (context.performed)
        {
            SecondaryFireEventPerformed?.Invoke();
            _secondaryFirePerformed = true;
        }
        else if(context.canceled)
        {
            SecondaryFireEventCanceled?.Invoke();
            _secondaryFirePerformed = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpEventStarted?.Invoke();
            _jumpPerformed = true;
        }
        else if (context.performed)
        {
            JumpEventPerformed?.Invoke();
            _jumpPerformed = true;
        }
        else if(context.canceled)
        {
            JumpEventCanceled?.Invoke();
            _jumpPerformed = false;
        }
    }
    
}
