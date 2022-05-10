
using UnityEngine;

public class MoveCommand : ICommand<Vector3>
{
    private Transform _transform;
    private float _speed;

    public MoveCommand(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }
    
    public void Do(Vector3 direction)
    {
        _transform.Translate(direction * (_speed*Time.deltaTime), Space.World);
    }
}
