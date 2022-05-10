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

    public bool Fallen => _fallen;
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;
    
    private void Awake()
    {
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _initialRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z,
            transform.rotation.w);
    }

    public void ResetPosition()
    {
        
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
}
