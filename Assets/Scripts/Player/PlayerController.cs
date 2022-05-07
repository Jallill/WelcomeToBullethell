using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, IObservable<bool>
{
    [SerializeField] private float _isGroundedDistance;
    [SerializeField] private Transform _groundedStartPosition;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private PlayerShieldController _playerShieldController;

    [SerializeField] private CapsuleCollider _collider;

    private bool _dead;
    public bool IsDead => _dead;
    
    private List<IObserver<bool>> _subscribers = new List<IObserver<bool>>();
    public List<IObserver<bool>> Subscribers => _subscribers;

    
    public bool IsGrounded()
    {
        float capsuleHeight = Mathf.Max(_collider.radius * 2f, _collider.height);
        Vector3 capsuleBottom = transform.TransformPoint(_collider.center - Vector3.up * capsuleHeight / 2f);
        float radius = transform.TransformVector(_collider.radius, 0f, 0f).magnitude;

        Ray ray = new Ray(capsuleBottom + transform.up * .01f, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, radius * 5f, _groundLayer))
        {
            float normalAngle = Vector3.Angle(hit.normal, transform.up);
            if (normalAngle < _isGroundedDistance)
            {
                float maxDist = radius / Mathf.Cos(Mathf.Deg2Rad * normalAngle) - radius + .02f;
                return hit.distance < maxDist;

            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_groundedStartPosition.position, _groundedStartPosition.position + Vector3.down * _isGroundedDistance);
    }

    private void Die()
    {
        _dead = true;
        NotifyAll(true);
        gameObject.SetActive(false);
    }
    
    public void TakeDamage(float damage, DamageType damageType)
    {
        if (_playerShieldController.ActiveShield != null && 
            _playerShieldController.ActiveShield.DefenseType == damageType) return;
        _healthController.ReduceHealth(damage);
        if (_healthController.CurrentHealth <= 0) Die(); 
    }

    public void Subscribe(IObserver<bool> observer)
    {
        if (_subscribers.Contains(observer)) return;
        _subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver<bool> observer)
    {
        if (!_subscribers.Contains(observer)) return;
        _subscribers.Remove(observer);
    }

    public void NotifyAll(bool message, params object[] args)
    {
        _subscribers.ForEach((observer) => {observer.OnNotify(message);});
    }
}