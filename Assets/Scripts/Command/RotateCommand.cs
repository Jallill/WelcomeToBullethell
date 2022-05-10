
using UnityEngine;

public class RotateCommand : ICommand<Vector3>
{
    private Transform _transform;

    public RotateCommand(Transform transform)
    {
        _transform = transform;
    }
    
    public void Do(Vector3 direction)
    {
        _transform.LookAt(direction);
    }
}