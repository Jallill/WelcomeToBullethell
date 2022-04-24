using UnityEngine;
using UnityEngine.InputSystem;

public delegate void InputEventHandler();

public class PlayerInput : MonoBehaviour
{
    public event InputEventHandler FireEvent;
    private Vector2 _movement;
    public Vector2 Movement => _movement;

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FireEvent?.Invoke();    
        }
    }
}
