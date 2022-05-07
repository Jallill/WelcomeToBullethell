using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidEnemy : Enemy, IObserver<bool>
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _damageLayer;
    
    private void Start()
    {
        _levelController.WinCondition.Subscribe(this);
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

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null && ((1<<other.gameObject.layer) & _damageLayer) != 0)
        {
            damageable.TakeDamage(_damage, DamageType.DefaultDamage);
        }
    }

    public void OnNotify(bool result, params object[] args)
    {
        if (result)
        {
            gameObject.SetActive(false);
        }
    }
}
