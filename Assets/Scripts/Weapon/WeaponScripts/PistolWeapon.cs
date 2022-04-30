
using UnityEngine;

public class PistolWeapon : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        var bullet = Instantiate(_weaponSO.Bullet, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
        bullet.Init(_bulletSpawnPosition.forward);
        base.Shoot(direction);
    }
}
