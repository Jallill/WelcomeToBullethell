using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour, IDamageable<DamageType>, IEnemy
{

    [SerializeField] protected EnemySO _enemySo;
    [SerializeField] protected HealthController _healthController;
    [SerializeField] protected EnemyBulletPattern _enemyBulletPattern;
    [SerializeField] protected EnemyMovement _enemyMovement;

    [SerializeField] private bool _canShoot;
    
    private void Awake()
    {
        _healthController.MaxHealth = _enemySo.MaxHealth;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _enemySo.Material;
    }

    public virtual void DealDamage(float damage, DamageType damageType)
    {
        _healthController.ReduceHealth(damage);
        if(_healthController.CurrentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        if (_canShoot) Shoot();
    }

    public virtual void Shoot()
    {
        _enemyBulletPattern.Shoot(transform.position, transform.rotation, _enemySo.Bullet);
    }
}