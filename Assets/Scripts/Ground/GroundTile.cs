using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour, IGroundTile
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _fallForce;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private bool _fallen;
    private bool _playerOnMe;
    
    public bool Fallen => _fallen;
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;
    public bool PlayerOnMe => _playerOnMe;
    
    private void Awake()
    {
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _initialRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z,
            transform.rotation.w);
    }

    public void ResetPosition()
    {
        gameObject.SetActive(true);
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        
    }

    public void Fall()
    {
        _rigidbody.isKinematic = false;
        _fallen = true;
        Invoke(nameof(Deactivate), 2f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            _playerOnMe = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerOnMe = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _playerOnMe ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
