using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponSO _weaponSO;
    [SerializeField] private Transform _bulletSpawnPosition;
    
    public void Shoot(Vector3 direction)
    {
        var bullet = Instantiate(_weaponSO.Bullet, _bulletSpawnPosition.position, transform.rotation);
        bullet.Init(_bulletSpawnPosition.forward);
        Debug.DrawLine(_bulletSpawnPosition.position, _bulletSpawnPosition.forward + _bulletSpawnPosition.forward*1000, Color.magenta, 1000000);
    }
}