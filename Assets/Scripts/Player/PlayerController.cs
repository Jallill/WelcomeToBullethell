using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _isGroundedDistance;
    [SerializeField] private Transform _groundedStartPosition;

    public bool IsGrounded()
    {
        return Physics.Raycast(_groundedStartPosition.position, Vector3.down, _isGroundedDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_groundedStartPosition.position, _groundedStartPosition.position + Vector3.down * _isGroundedDistance);
    }
}