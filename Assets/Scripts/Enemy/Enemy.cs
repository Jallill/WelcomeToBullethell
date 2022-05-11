using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour, IDamageable, IEnemy
{

    [SerializeField] protected EnemySO _enemySo;
    [SerializeField] protected HealthController _healthController;
    [SerializeField] protected EnemyBulletPattern _enemyBulletPattern;
    [SerializeField] protected EnemyMovement _enemyMovement;

    [SerializeField] private bool _canShoot;

    private bool _dead;
    
    private void Awake()
    {
        _healthController.MaxHealth = _enemySo.MaxHealth;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _enemySo.Material;
        
    }

    protected virtual void Start()
    {
        if (_canShoot) _enemyBulletPattern.InitShootCommands(_enemySo.Bullets);
    }

    public virtual void TakeDamage(float damage, DamageType damageType)
    {
        _healthController.ReduceHealth(damage);
        if(_healthController.CurrentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        // Destroy(gameObject);
        _dead = true;
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (_canShoot) Shoot();
    }

    public virtual void Shoot()
    {
        _enemyBulletPattern.Shoot(_enemySo.Bullets[0]);
    }

    public bool IsDead()
    {
        return _dead;
    }
}