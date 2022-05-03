using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable<DamageType>
{
    [SerializeField] private float _isGroundedDistance;
    [SerializeField] private Transform _groundedStartPosition;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private PlayerShieldController _playerShieldController;

    public bool IsGrounded()
    {
        return Physics.Raycast(_groundedStartPosition.position, Vector3.down, _isGroundedDistance, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_groundedStartPosition.position, _groundedStartPosition.position + Vector3.down * _isGroundedDistance);
    }

    public void DealDamage(float damage, DamageType damageType)
    {
        if (_playerShieldController.ActiveShield != null && 
            _playerShieldController.ActiveShield.DefenseType == damageType) return;
        _healthController.ReduceHealth(damage);
    }
}