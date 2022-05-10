
using UnityEngine;

public class JumpCommand : ICommand
{
    private Rigidbody _rigidbody;
    private float _jumpForce;

    public JumpCommand(Rigidbody rigidbody, float jumpForce)
    {
        _rigidbody = rigidbody;
        _jumpForce = jumpForce;
    }
    
    public void Do()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
    }
}
