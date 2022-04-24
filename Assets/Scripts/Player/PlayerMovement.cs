using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [Range(0, 20)] [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(new Vector3(_playerInput.Movement.x, 0, _playerInput.Movement.y) * (Time.deltaTime * _speed), Space.World);
    }
}