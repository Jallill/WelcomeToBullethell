using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Range(0,1)][SerializeField] private float _speed;
    
    private Vector3 _offset;
    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    void LateUpdate() 
    {
        var targetPosition = _player.transform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _speed);
    }
}
