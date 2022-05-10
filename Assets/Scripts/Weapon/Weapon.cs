using System;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected WeaponSO _weaponSO;
    [SerializeField] protected Transform _bulletSpawnPosition;
    [SerializeField] protected ShootCommand _shootCommand;

    private float _cooldown;
    protected bool OnCooldown => Time.time < _cooldown;

    private void Awake()
    {
        _shootCommand = new ShootCommand(_weaponSO.Bullet.Data, _bulletSpawnPosition);
    }

    public virtual void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        _cooldown = Time.time + _weaponSO.RateOfFire;
    }
}