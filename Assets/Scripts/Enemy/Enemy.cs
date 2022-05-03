using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable<DamageType>, IEnemy
{

    [SerializeField] protected EnemySO _enemySo;
    [SerializeField] protected HealthController _healthController;
    [SerializeField] protected EnemyBulletPattern enemyBulletPattern;

    [SerializeField] private bool _canShoot;
    
    private void Awake()
    {
        _healthController.MaxHealth = _enemySo.MaxHealth;
    }

    public void DealDamage(float damage, DamageType damageType)
    {
        _healthController.ReduceHealth(damage);
        if(_healthController.CurrentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_canShoot) Shoot();
    }

    public virtual void Shoot()
    {
        enemyBulletPattern.Shoot(transform.position, transform.rotation, _enemySo.Bullet);
    }
}