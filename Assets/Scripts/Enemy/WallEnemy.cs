
using System;
using UnityEngine;

public class WallEnemy : Enemy
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _travelDistance;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _damageLayer;
    
    
    private Vector3 _currentTravelPosition;
    private bool _travelingToEnd;

    private void Awake()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + transform.forward * _travelDistance;
        _currentTravelPosition = _endPosition;
    }

    public override void TakeDamage(float damage, DamageType damageType)
    {
        // Do nothing
    }

    protected override void Die()
    {
        //Do nothing
    }

    public override void Shoot()
    {
        //Do nothing
    }

    protected override void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (_currentTravelPosition-transform.position).normalized);
        _enemyMovement.Move((_currentTravelPosition-transform.position).normalized, _enemySo.MovementSpeed);
        if (Vector3.Distance(transform.position, _currentTravelPosition) <= 0.1f)
        {
            _travelingToEnd = !_travelingToEnd;
            _currentTravelPosition = _travelingToEnd ? _endPosition : _startPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null && ((1<<other.gameObject.layer) & _damageLayer) != 0)
        {
            damageable.TakeDamage(_damage, _damageType);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_startPosition, 1);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_endPosition, 1);
    }
}