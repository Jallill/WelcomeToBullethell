using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected WeaponSO _weaponSO;
    [SerializeField] protected Transform _bulletSpawnPosition;

    private float _cooldown;
    protected bool OnCooldown => Time.time < _cooldown;
    
    public virtual void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        _cooldown = Time.time + _weaponSO.RateOfFire;
    }
}